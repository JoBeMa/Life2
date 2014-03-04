/* Life 2.0 Backoffice code Copyright (C) 2014 - Fundació i2CAT This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA. */
package net.i2cat.csade.life2.backoffice.bl;


import java.rmi.RemoteException;
import java.util.Calendar;

import javax.xml.rpc.ServiceException;
import net.i2cat.csade.life2.backoffice.DAO.PlatformUserDAO;
import net.i2cat.csade.life2.backoffice.DAO.StatsDAO;
import net.i2cat.csade.life2.backoffice.model.JQueryDataTableParamModel;
import net.i2cat.csade.life2.backoffice.model.PlatformUser;
import net.i2cat.csade.life2.backoffice.model.User;
import net.i2cat.csade.life2.backoffice.clientws.b.dbservice.UserProfile;
import net.sf.json.JSONArray;
import net.sf.json.JSONException;
import net.sf.json.JSONObject;

import org.apache.commons.lang.StringEscapeUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class PlatformUserManager {

	Logger log = LoggerFactory.getLogger(this.getClass());
	PlatformUserDAO userDAO;
	
	public PlatformUserManager() {
		super();
		userDAO = new PlatformUserDAO();
	}

	public int login(String login, String pass) throws RemoteException, ServiceException {
		int result= userDAO.login(login, pass);
		if (result>=0)
		{
			StatsDAO sd=new StatsDAO();
			sd.addStats(login, StatsDAO.LOGIN_EVENT, Calendar.getInstance(), 0, "", "", "");
		}		
		return result;
	}
	
	public PlatformUser getUser(String login) throws RemoteException, ServiceException {
		return userDAO.get(login);
	}

	public int saveUser(PlatformUser user) throws RemoteException, ServiceException
	{
		int result=userDAO.insert(user);
		if (user.isNew() && result>0) //Si el usuario se ha dado de alta correctamente
		{
			StatsDAO sd=new StatsDAO();
			sd.addStats(user.getLogin(), StatsDAO.USER_ADDED, Calendar.getInstance(), 0, user.getHome_area_lat(), user.getHome_area_lon(), "");
		}
		return result;
	}
	
	public int deleteUser(String login) throws RemoteException,ServiceException {
		StatsDAO sd=new StatsDAO();
		sd.addStats(login, StatsDAO.USER_DELETED, Calendar.getInstance(), 0, "", "", "");
		int result=userDAO.delete(login);
		return result;
	}
	
	public int uploadFoto(String login,byte[] foto) throws RemoteException,ServiceException {
		return userDAO.uploadPicture(login, foto);
	}
	
	
	public String getLoginInLanguage(String lng)  throws RemoteException,ServiceException
	{
		UserProfile[] result=null;
		String filter="Language like '"+lng+"'";
		result=userDAO.getPlatformUsersFiltered(filter, 0, 1);	
		if (result.length>0)
			return result[0].getLogin();
		else
			return "***";
	}
	
	public JSONObject getPlatformUsersJSON(JQueryDataTableParamModel param) throws RemoteException,ServiceException
	{
		JSONObject jsonResponse = new JSONObject();
		UserProfile[] result=null;
		String filter="";
		if (param==null) throw new ServiceException("Invalid Session!");
		
		if (param.sSearch!=null && !"".equals(param.sSearch))
		{
			filter="Name like '%"+param.sSearch+"%' or Login like '%"+param.sSearch+"%' ";
		}
		if (param.iCallerRole!=6)
		{
			if (!"".equals(filter))
			{
				filter+=" AND ";
			}			
			filter+="Role<>6 AND Role <"+param.iCallerRole;
		}
		if (param.iRole>=0)
		{
			if (!"".equals(filter))
			{
				filter+=" AND ";
			}
			filter+="Role="+param.iRole;
		}
		
		if (param.sLng!=null && !"".equals(param.sLng))
		{
			if (!"".equals(filter))
			{
				filter+=" AND ";
			}
			filter+="Language like '"+param.sLng+"'";
		}		
		
		if (param.iCallerRole==5)
		{
			if (!"".equals(filter))
			{
				filter+=" AND ";
			}			
			filter+=" isInRegion(region,'&','"+param.sRegion+"')=1  ";
		}
		if (param.iCallerRole==7)
		{
			if (!"".equals(filter))
			{
				filter+=" AND ";
			}			
			filter+=" cisInSupraRegion(region,'&','"+param.sRegion+"')=1 ";
		}
		if (param.iCallerRole==8)
		{
			if (!"".equals(filter))
			{
				filter+=" AND ";
			}			
			filter+=" isInCtryCode(region,'&','"+param.sRegion+"')=1 ";
		}		
		int total=userDAO.countPlatformUsersFiltered(filter);
		result=userDAO.getPlatformUsersFiltered(filter, param.iDisplayStart, param.iDisplayLength);	

		if (result!=null)
		{
			try {
				jsonResponse.put("iTotalRecords", total ); //El total despues de filtrar
			    jsonResponse.put("iTotalDisplayRecords", total);
			    JSONArray data = new JSONArray();
			    for(UserProfile u : result){
			        JSONArray row = new JSONArray();
			        row.add( "<a href=\"#\" onclick=\"showFormPlatform('"+u.getLogin()+"',"+u.getUser_id()+");\">"+u.getUser_id()+"</a>");
			        row.add(StringEscapeUtils.escapeHtml(u.getLogin()));
			        row.add(StringEscapeUtils.escapeHtml(u.getName()));
			        row.add(PlatformUser.roleNames[u.getRole()]);
			        //row.add(u.getName().replaceAll("‡", "&aacute;").replaceAll("Ž", "&eacute;").replaceAll("’", "&iacute;").replaceAll("—", "&oacute;").replaceAll("œ", "&uacute;").replaceAll("–", "&ntilde;"));
			        row.add(u.getLast_location_timestamp());
			        row.add(u.getEmail());
			        data.add(row);
			    }
				jsonResponse.put("sEcho", param.sEcho);
			    jsonResponse.put("aaData", data);
			} catch (JSONException e) {
			}
			
		}
		else
		{
			jsonResponse.put("aaData", "[]");
		}
		return jsonResponse;
	}
	
	
}

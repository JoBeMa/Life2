/* Life 2.0 Backoffice code Copyright (C) 2014 - Fundació i2CAT This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA. */

package net.i2cat.csade.life2.backoffice.bl;

import java.rmi.RemoteException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.HashMap;
import java.util.Hashtable;

import javax.xml.rpc.ServiceException;

import org.apache.commons.lang.StringEscapeUtils;

import net.i2cat.csade.life2.backoffice.DAO.PlatformUserDAO;
import net.i2cat.csade.life2.backoffice.DAO.StatsDAO;
import net.i2cat.csade.life2.backoffice.model.JQueryDataTableParamModel;
import net.i2cat.csade.life2.backoffice.model.Pair;
import net.i2cat.csade.life2.backoffice.model.PlatformUser;
import net.i2cat.csade.life2.backoffice.model.Region;
import net.i2cat.csade.life2.backoffice.util.PasswordGenerator;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.Activity;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.Category;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.FilteringPrefs;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.ObjStats;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.Offer;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.Regions;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.Request;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.Service;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.Skill;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.Status;
import net.sf.json.JSONArray;
import net.sf.json.JSONException;
import net.sf.json.JSONObject;

public class StatisticsManager {
	public final String STATE_ALL="all";
	public final String STATE_ACTIVE="active";
	public final String STATE_PAST="past";
	public final String STATE_ALWAYS="always";
	
	StatsDAO sd=null;
	SimpleDateFormat df;
	PlatformUserDAO userDAO;
	
	public StatisticsManager() {
		this.sd=new StatsDAO();
		userDAO=new PlatformUserDAO();
		df= new SimpleDateFormat("dd/MM/yyyy");
	}
	
	/**
	 * Returns number of connections thru different hours in one day
	 * @return
	 */
	public String getDatosConexiones() {
		ObjStats[] st=null;
		ArrayList<Pair> datos=new ArrayList<Pair>();
		try {
			String sql="SELECT Hour(t2.dTime) as idStat,count(*) as Event,\"\" as User_login,\"\" as dTime,0 as duration,\"\" as lat,\"\" as lon,\"\" as device,\"\" as query,0 as lng  FROM (SELECT * FROM  `Stat` WHERE event="+StatsDAO.LOGIN_EVENT +") AS t2 GROUP BY Hour(t2.dTime) ORDER BY Hour(t2.dTime)";
			st=sd.listStatsSQL(sql);
		} catch (RemoteException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (ServiceException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		for (int i=0;i<st.length;i++)
		{
			datos.add(new Pair(""+st[i].getIdStat(),st[i].getIEvent()));
		}
		
		return datos.toString();
	}

	/**
	 * Returns the number of logins in the last xx days, grouped by day
	 * @param days
	 * @return
	 */
	public String getDatosConexionesDia(int days,int role,String lng) {
		ObjStats[] st=null;
		String sql;
		ArrayList<Pair> datos=new ArrayList<Pair>();
		Pair p;
		try {
			if (role>=0 && !"all".equals(lng))
				sql="SELECT 0 as idStat,count(*) as Event,\"\" as User_login,DATE(dTime) as dTime,0 as duration,\"\" as lat,\"\" as lon,\"\" as device,\"\" as query,0 as lng  FROM (SELECT * FROM  `Stat` INNER JOIN user_profile ON user_profile.Login=`Stat`.User_login AND user_profile.Role="+role+" AND user_profile.Language like '"+lng+"' WHERE event="+StatsDAO.LOGIN_EVENT +" and DATE(dTime)<=CURDATE() and (DATE(dTime)>DATE_ADD(CURDATE(), INTERVAL -"+days+" DAY)) ) AS t2 GROUP BY DATE(dTime)";
			else if (role>=0)
				sql="SELECT 0 as idStat,count(*) as Event,\"\" as User_login,DATE(dTime) as dTime,0 as duration,\"\" as lat,\"\" as lon,\"\" as device,\"\" as query,0 as lng  FROM (SELECT * FROM  `Stat` INNER JOIN user_profile ON user_profile.Login=`Stat`.User_login AND user_profile.Role="+role+" WHERE event="+StatsDAO.LOGIN_EVENT +" and DATE(dTime)<=CURDATE() and (DATE(dTime)>DATE_ADD(CURDATE(), INTERVAL -"+days+" DAY)) ) AS t2 GROUP BY DATE(dTime)";
			else if (!"all".equals(lng))
				sql="SELECT 0 as idStat,count(*) as Event,\"\" as User_login,DATE(dTime) as dTime,0 as duration,\"\" as lat,\"\" as lon,\"\" as device,\"\" as query,0 as lng  FROM (SELECT * FROM  `Stat` INNER JOIN user_profile ON user_profile.Login=`Stat`.User_login AND user_profile.Language like '"+lng+"' WHERE event="+StatsDAO.LOGIN_EVENT +" and DATE(dTime)<=CURDATE() and (DATE(dTime)>DATE_ADD(CURDATE(), INTERVAL -"+days+" DAY)) ) AS t2 GROUP BY DATE(dTime)";				
			else
				sql="SELECT 0 as idStat,count(*) as Event,\"\" as User_login,DATE(dTime) as dTime,0 as duration,\"\" as lat,\"\" as lon,\"\" as device,\"\" as query,0 as lng  FROM (SELECT * FROM  `Stat` WHERE event="+StatsDAO.LOGIN_EVENT +" and DATE(dTime)<=CURDATE() and (DATE(dTime)>DATE_ADD(CURDATE(), INTERVAL -"+days+" DAY)) ) AS t2 GROUP BY DATE(dTime)";
			
			st=sd.listStatsSQL(sql);
		} catch (RemoteException e) {
			e.printStackTrace();
		} catch (ServiceException e) {
			
			e.printStackTrace();
		}
		for (int i=0;i<st.length;i++)
		{
			datos.add(new Pair(this.weDontSpeakAmericano(st[i].getDTime()),st[i].getIEvent()));
		}
		
		return datos.toString();
	}
	
	/**
	 * Returns the necessary data to build a pie with the tipe of connections
	 * @return
	 */
	public String getDatosDispositivos() {
		
		int iPads=0,androids=0,others=0;
		
		try {
			androids=sd.countStats(" Event="+StatsDAO.LOGIN_EVENT+" and Device like '%ndroid%' "); //
			iPads=sd.countStats("Event="+StatsDAO.LOGIN_EVENT+" and Device like '%iPad%'");
			others=sd.countStats(" Event="+StatsDAO.LOGIN_EVENT)+(-androids)+(-iPads);
		}
		catch (RemoteException e) {
			 	iPads=0;
			 	androids=0;
			 	others=0;
				e.printStackTrace();
		} catch (ServiceException e) {
			 	iPads=0;
			 	androids=0;
			 	others=0;
				e.printStackTrace();
		}
		Pair p1=new Pair("Ipad connections",iPads);
		Pair p2=new Pair("Android connections",androids);
		Pair p3=new Pair("PCs and others",others);
		
		ArrayList<Pair> datos=new ArrayList<Pair>();
		datos.add(p1);
		datos.add(p2);
		datos.add(p3);
		return datos.toString();
	}

	public String getDatosProfiles() {
		ObjStats[] st=null;
		ArrayList<Pair> datos=new ArrayList<Pair>();
		HashMap<Integer,Pair> hm=new HashMap<Integer, Pair>();
		Pair p;
		try {
			String sql="SELECT t2.role as idStat,count(*) as Event,\"\" as User_login,null as dTime,0 as duration,\"\" as lat,\"\" as lon,\"\" as device,\"\" as query,0 as lng  FROM (SELECT s.*,u.role FROM Stat AS s INNER JOIN user_profile AS u ON s.User_login=u.Login AND s.event="+StatsDAO.LOGIN_EVENT +" ) AS t2 GROUP BY (role)";
			st=sd.listStatsSQL(sql);
		} catch (RemoteException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (ServiceException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		for (int i=0;i<st.length;i++)
		{
			if (!hm.containsKey(new Integer(st[i].getIdStat())))
			{
				datos.add(new Pair(PlatformUser.roleNames[st[i].getIdStat()],st[i].getIEvent()));
				hm.put(new Integer(st[i].getIdStat()), new Pair(PlatformUser.roleNames[st[i].getIdStat()],st[i].getIEvent()));
			}
			else
			{
				Pair anterior=hm.get(new Integer(st[i].getIdStat()));
				datos.remove(anterior);	
				anterior=new Pair(PlatformUser.roleNames[st[i].getIdStat()],anterior.getValue()+st[i].getIEvent());
				datos.add(anterior);
				hm.put(new Integer(st[i].getIdStat()), anterior);
			}
		}		
		return datos.toString();
	}	

	public String getDatosNewUsersByDay(int days,int role,String lng) {
		ObjStats[] st=null;
		ArrayList<Pair> datos=new ArrayList<Pair>();
		Pair p;
		String sql;
		try {
			if (role>=0 && !"all".equals(lng))
				sql="SELECT 0 as idStat,count(*) as Event,\"\" as User_login,DATE(dTime) as dTime,0 as duration,\"\" as lat,\"\" as lon,\"\" as device,\"\" as query,0 as lng  FROM (SELECT * FROM  `Stat` INNER JOIN user_profile ON user_profile.Login=`Stat`.User_login AND user_profile.Role="+role+" AND user_profile.Language like '"+lng+"' WHERE event="+StatsDAO.USER_ADDED +" and DATE(dTime)<=CURDATE() and (DATE(dTime)>DATE_ADD(CURDATE(), INTERVAL -"+days+" DAY)) ) AS t2 GROUP BY DATE(dTime)";
			else if (role>=0)
				sql="SELECT 0 as idStat,count(*) as Event,\"\" as User_login,DATE(dTime) as dTime,0 as duration,\"\" as lat,\"\" as lon,\"\" as device,\"\" as query,0 as lng  FROM (SELECT * FROM  `Stat` INNER JOIN user_profile ON user_profile.Login=`Stat`.User_login AND user_profile.Role="+role+" WHERE event="+StatsDAO.USER_ADDED +" and DATE(dTime)<=CURDATE() and (DATE(dTime)>DATE_ADD(CURDATE(), INTERVAL -"+days+" DAY)) ) AS t2 GROUP BY DATE(dTime)";
			else if (!"all".equals(lng))
				sql="SELECT 0 as idStat,count(*) as Event,\"\" as User_login,DATE(dTime) as dTime,0 as duration,\"\" as lat,\"\" as lon,\"\" as device,\"\" as query,0 as lng  FROM (SELECT * FROM  `Stat` INNER JOIN user_profile ON user_profile.Login=`Stat`.User_login AND user_profile.Language like '"+lng+"' WHERE event="+StatsDAO.USER_ADDED +" and DATE(dTime)<=CURDATE() and (DATE(dTime)>DATE_ADD(CURDATE(), INTERVAL -"+days+" DAY)) ) AS t2 GROUP BY DATE(dTime)";				
			else
				sql="SELECT 0 as idStat,count(*) as Event,\"\" as User_login,DATE(dTime) as dTime,0 as duration,\"\" as lat,\"\" as lon,\"\" as device,\"\" as query,0 as lng  FROM (SELECT * FROM  `Stat` WHERE event="+StatsDAO.USER_ADDED +" and DATE(dTime)<=CURDATE() and (DATE(dTime)>DATE_ADD(CURDATE(), INTERVAL -"+days+" DAY)) ) AS t2 GROUP BY DATE(dTime)";
			st=sd.listStatsSQL(sql);
		} catch (RemoteException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (ServiceException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		for (int i=0;i<st.length;i++)
		{
			datos.add(new Pair(this.weDontSpeakAmericano(st[i].getDTime()),st[i].getIEvent()));
		}
		
		return datos.toString();
	}

	public String getDatosEventsPost(int numDays) {
		ArrayList<Pair> datos=new ArrayList<Pair>();
		int num;
		Pair p;
		Calendar c=Calendar.getInstance();
		SimpleDateFormat americano=new SimpleDateFormat("MM/dd/yyyy");
		try 
		{
			for(int i=(-1*numDays);i<=0;i++)
			{
				c=Calendar.getInstance();
				c.add(Calendar.DATE, i);
				num=sd.countActivities(" adddate(date(curdate()),"+i+") = date(deadline)"); 
				//num+=(int)(10.0* Math.random());
				p=new Pair(americano.format(c.getTime()) ,num);
				datos.add(p);
			}
		}
		catch(Exception ex) {}
		return datos.toString();
	}

	public String getDatosHelpRequested() {
		// TODO Auto-generated method stub
		return null;
	} 

	public String getDatosHelpOffered() {
		ArrayList<Pair> datos=new ArrayList<Pair>();
		try 
		{
			Category[] categories=sd.listCategories("", 0, 0,"");
			Pair pair=null;
			int num;
			for(Category c: categories)
			{
				num=sd.countOffers("category_id="+c.getCategory_id() );
				if (num>0)
				{
					pair=new Pair(StringEscapeUtils.escapeHtml(c.getCategory_name())+" ("+num+")", num);
					datos.add(pair);
				}
				
			}
		}
		catch(Exception ex) {}
		return datos.toString();
	}

	public String getDatosHelpReceived() {
		// TODO Auto-generated method stub
		return null;
	}	
	
	
	public JSONObject getListByCategoriesJSON(JQueryDataTableParamModel param,
			boolean showAll) throws RemoteException, ServiceException {
		Category[] result=null;
		JSONObject jsonResponse = new JSONObject();
		int total=0;
		String login="";
		String filter="";
		if (param==null) throw new ServiceException("Invalid Session!");
		if (param.sSearch!=null && !"".equals(param.sSearch))
		{
			filter="category_name like '%"+param.sSearch+"%' or category_description like '%"+param.sSearch+"%' ";
		}		
		if (!showAll)
			login=param.login;
		result=sd.listCategories(filter, param.iDisplayStart, param.iDisplayLength,login);
		if (filter==null||"".equals(filter.trim()))
			total=sd.countCategories(login);
		else
			total=sd.countCategories(filter,login);
		if (!"***".equals(login) && result!=null)
		{
			try {
				jsonResponse.put("iTotalRecords", total ); //El total despues de filtrar
			    jsonResponse.put("iTotalDisplayRecords", total);
			    JSONArray data = new JSONArray();
				for(Category c : result){
			        JSONArray row = new JSONArray();
			        filter="category_id="+c.getCategory_id();
			        //Comptem
			        //int numReq= sd.countRequests( filter,login); 
			        int numOff=sd.countOffers( filter,login) ;
			        //int numServ=sd.countServices( filter,login);

			        row.add(StringEscapeUtils.escapeHtml(c.getCategory_name()));
		        	//row.add(""+numReq);
			        row.add(""+numOff);
			        //row.add(""+numServ);
			        data.add(row);
			    }
				jsonResponse.put("sEcho", param.sEcho);
			    jsonResponse.put("aaData", data);
			} catch (JSONException e) {
			}
			
		}
		else
		{
			jsonResponse.put("iTotalRecords", 0 ); //El total despues de filtrar
		    jsonResponse.put("iTotalDisplayRecords", 0);
		    jsonResponse.put("sEcho", param.sEcho);
			jsonResponse.put("aaData", "[]");
		}
		return jsonResponse;	
	}
	
	
	public JSONObject getListActivitiesByCategoriesJSON(JQueryDataTableParamModel param,
			boolean showAll) throws RemoteException, ServiceException {
		Category[] result=null;
		JSONObject jsonResponse = new JSONObject();
		int total=0;
		String login="";
		String filter="";
		if (param==null) throw new ServiceException("Invalid Session!");
		if (param.sSearch!=null && !"".equals(param.sSearch))
		{
			filter="category_name like '%"+param.sSearch+"%' or category_description like '%"+param.sSearch+"%' ";
		}		
		if (!showAll)
			login=param.login;
		result=sd.listActCategories(filter, param.iDisplayStart, param.iDisplayLength,login);
		if (filter==null||"".equals(filter.trim()))
			total=sd.countActCategories(login);
		else
			total=sd.countActCategories(filter,login);
		if (result!=null)
		{
			try {
				jsonResponse.put("iTotalRecords", total ); //El total despues de filtrar
			    jsonResponse.put("iTotalDisplayRecords", total);
			    JSONArray data = new JSONArray();
				for(Category c : result){
			        JSONArray row = new JSONArray();
			        filter="category_id="+c.getCategory_id();
			        //Comptem
			        int numAct= sd.countActivities( filter,login); 
			        row.add(StringEscapeUtils.escapeHtml(c.getCategory_name()));
		        	row.add(""+numAct);
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
	
	
	public JSONObject getListServicesByCategoriesJSON(JQueryDataTableParamModel param,
			boolean showAll) throws RemoteException, ServiceException {
		Category[] result=null;
		JSONObject jsonResponse = new JSONObject();
		int total=0;
		String login="";
		String filter="";
		if (param==null) throw new ServiceException("Invalid Session!");
		if (param.sSearch!=null && !"".equals(param.sSearch))
		{
			filter="category_name like '%"+param.sSearch+"%' or category_description like '%"+param.sSearch+"%' ";
		}		
		if (!showAll)
			login=param.login;
		result=sd.listCompCategories(filter, param.iDisplayStart, param.iDisplayLength,login);
		if (filter==null||"".equals(filter.trim()))
			total=sd.countCompCategories(login);
		else
			total=sd.countActCategories(filter,login);
		if (result!=null)
		{
			try {
				jsonResponse.put("iTotalRecords", total ); //El total despues de filtrar
			    jsonResponse.put("iTotalDisplayRecords", total);
			    JSONArray data = new JSONArray();
				for(Category c : result){
			        JSONArray row = new JSONArray();
			        filter="category_id="+c.getCategory_id();
			        //Comptem
			        int numAct= sd.countServices( filter,login); 
			        row.add(StringEscapeUtils.escapeHtml(c.getCategory_name()));
		        	row.add(""+numAct);
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
	
	/****************************************************/
	/*  					CATEGORIES                  */	
	/*  									            */
	/****************************************************/
	
	public JSONObject getCategory(String id)  throws RemoteException, ServiceException
	{
		Category[] result=null;
		result=sd.listCategories("category_id="+id, 0, 0,"");
		JSONObject jso=new JSONObject();
		if (result!=null && result.length>0 )
		{
	        JSONArray row = new JSONArray();
	        row.add(result[0].getCategory_id());
	        row.add(result[0].getCategory_name());
	        if (result[0].getCategory_desc()!=null)
	        	row.add(result[0].getCategory_desc());
	        else
	        	row.add("");
	        row.add(""+result[0].getStatus());
	        row.add(result[0].getLng());

	        jso.put("aaData", row);
			
		}
		else
			throw new ServiceException("category whith id "+id+" not found");
		return jso;
	}
	
	public JSONObject getListCategoriesJSON(JQueryDataTableParamModel param, boolean showAll) throws RemoteException, ServiceException 
	{
		JSONObject jsonResponse = new JSONObject();
		Category[] result=null;
		String[] statuses={"SError","Submitted","Pending","Pending Approval","Accepted","Closed","Rejected","Rejected","Rejected"};
		String filter="";
		if (param==null) throw new ServiceException("Invalid Session!");
		if (param.sSearch!=null && !"".equals(param.sSearch))
		{
			filter="category_name like '%"+param.sSearch+"%' or category_description like '%"+param.sSearch+"%' ";
		}
		int total=0;
		String login="";
		if (!showAll)
			login=param.login;
		if (filter==null||"".equals(filter.trim()))
			total=sd.countCategories(login);
		else
			total=sd.countCategories(filter,login);
		result=sd.listCategories(filter, param.iDisplayStart, param.iDisplayLength,login);
						
		if (result!=null)
		{
			try {
				jsonResponse.put("iTotalRecords", total ); //El total despues de filtrar
			    jsonResponse.put("iTotalDisplayRecords", total);
			    JSONArray data = new JSONArray();

			    for(Category c : result){
			        JSONArray row = new JSONArray();
			        row.add( "<a href=\"#\" onclick=\"showFormCategory('"+c.getCategory_id()+"');\">"+c.getCategory_id()+"</a>");
			        row.add(StringEscapeUtils.escapeHtml(c.getCategory_name()));
			        if (c.getCategory_desc()!=null)
			        	row.add(StringEscapeUtils.escapeHtml(c.getCategory_desc()));
			        else
			        	row.add("");
			        row.add(statuses[c.getStatus()]);
			        row.add(c.getLng());
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
	
	public int saveCategory(String login,int id,String name, int status, String description) throws ServiceException,RemoteException
	{
		return sd.saveCategory(login,id, name,status, description);
	}
	
	public int deleteCategory(String login,int id,String name, String description)  throws ServiceException,RemoteException
	{
		return sd.deleteCategory(login, id, name, description);
	}
	
	
	/****************************************************/
	/*  			ACTIVITY CATEGORIES                 */	
	/*  									            */
	/****************************************************/
	
	public JSONObject getActCategory(String id)  throws RemoteException, ServiceException
	{
		Category[] result=null;
		result=sd.listActCategories("category_id="+id, 0, 0,"");
		JSONObject jso=new JSONObject();
		if (result!=null && result.length>0 )
		{
	        JSONArray row = new JSONArray();
	        row.add(result[0].getCategory_id());
	        row.add(result[0].getCategory_name());
	        if (result[0].getCategory_desc()!=null)
	        	row.add(result[0].getCategory_desc());
	        else
	        	row.add("");
	        row.add(""+result[0].getStatus());
	        row.add(result[0].getLng());

	        jso.put("aaData", row);
			
		}
		else
			throw new ServiceException("category whith id "+id+" not found");
		return jso;
	}
	
	public JSONObject getListActCategoriesJSON(JQueryDataTableParamModel param, boolean showAll) throws RemoteException, ServiceException 
	{
		JSONObject jsonResponse = new JSONObject();
		Category[] result=null;
		String[] statuses={"SError","Submitted","Pending","Pending Approval","Accepted","Closed","Rejected","Rejected","Rejected"};
		String filter="";
		if (param==null) throw new ServiceException("Invalid Session!");
		if (param.sSearch!=null && !"".equals(param.sSearch))
		{
			filter="category_name like '%"+param.sSearch+"%' or category_desc like '%"+param.sSearch+"%' ";
		}
		int total=0;
		String login="";
		if (!showAll)
			login=param.login;
		if (filter==null||"".equals(filter.trim()))
			total=sd.countActCategories(login);
		else
			total=sd.countActCategories(filter,login);
		result=sd.listActCategories(filter, param.iDisplayStart, param.iDisplayLength,login);
						
		if (result!=null)
		{
			try {
				jsonResponse.put("iTotalRecords", total ); //El total despues de filtrar
			    jsonResponse.put("iTotalDisplayRecords", total);
			    JSONArray data = new JSONArray();

			    for(Category c : result){
			        JSONArray row = new JSONArray();
			        row.add( "<a href=\"#\" onclick=\"showFormActCategory('"+c.getCategory_id()+"');\">"+c.getCategory_id()+"</a>");
			        row.add(StringEscapeUtils.escapeHtml(c.getCategory_name()));
			        if (c.getCategory_desc()!=null)
			        	row.add(StringEscapeUtils.escapeHtml(c.getCategory_desc()));
			        else
			        	row.add("");
			        row.add(statuses[c.getStatus()]);
			        row.add(c.getLng());
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
	
	public int saveActCategory(String login,int id,String name, int status, String description) throws ServiceException,RemoteException
	{
		return sd.saveActCategory(login,id, name,status, description);
	}
	
	public int deleteActCategory(String login,int id,String name, String description)  throws ServiceException,RemoteException
	{
		return sd.deleteActCategory(login, id, name, description);
	}	

	/****************************************************/
	/*  			COMPANY SERVICES CATEGORIES         */	
	/*  									            */
	/****************************************************/
	
	public JSONObject getCompCategory(String id)  throws RemoteException, ServiceException
	{
		Category[] result=null;
		result=sd.listCompCategories("category_id="+id, 0, 0,"");
		JSONObject jso=new JSONObject();
		if (result!=null && result.length>0 )
		{
	        JSONArray row = new JSONArray();
	        row.add(result[0].getCategory_id());
	        row.add(result[0].getCategory_name());
	        if (result[0].getCategory_desc()!=null)
	        	row.add(result[0].getCategory_desc());
	        else
	        	row.add("");
	        row.add(""+result[0].getStatus());
	        row.add(result[0].getLng());

	        jso.put("aaData", row);
			
		}
		else
			throw new ServiceException("category whith id "+id+" not found");
		return jso;
	}
	
	public JSONObject getListCompCategoriesJSON(JQueryDataTableParamModel param, boolean showAll) throws RemoteException, ServiceException 
	{
		JSONObject jsonResponse = new JSONObject();
		Category[] result=null;
		String[] statuses={"SError","Submitted","Pending","Pending Approval","Accepted","Closed","Rejected","Rejected","Rejected"};
		String filter="";
		if (param==null) throw new ServiceException("Invalid Session!");
		if (param.sSearch!=null && !"".equals(param.sSearch))
		{
			filter="category_name like '%"+param.sSearch+"%' or category_desc like '%"+param.sSearch+"%' ";
		}
		int total=0;
		String login="";
		if (!showAll)
			login=param.login;
		if (filter==null||"".equals(filter.trim()))
			total=sd.countCompCategories(login);
		else
			total=sd.countCompCategories(filter,login);
		result=sd.listCompCategories(filter, param.iDisplayStart, param.iDisplayLength,login);
						
		if (result!=null)
		{
			try {
				jsonResponse.put("iTotalRecords", total ); //El total despues de filtrar
			    jsonResponse.put("iTotalDisplayRecords", total);
			    JSONArray data = new JSONArray();

			    for(Category c : result){
			        JSONArray row = new JSONArray();
			        row.add( "<a href=\"#\" onclick=\"showFormCompCategory('"+c.getCategory_id()+"');\">"+c.getCategory_id()+"</a>");
			        row.add(StringEscapeUtils.escapeHtml(c.getCategory_name()));
			        if (c.getCategory_desc()!=null)
			        	row.add(StringEscapeUtils.escapeHtml(c.getCategory_desc()));
			        else
			        	row.add("");
			        row.add(statuses[c.getStatus()]);
			        row.add(c.getLng());
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
	
	public int saveCompCategory(String login,int id,String name, int status, String description) throws ServiceException,RemoteException
	{
		return sd.saveCompCategory(login,id, name,status, description);
	}
	
	public int deleteCompCategory(String login,int id,String name, String description)  throws ServiceException,RemoteException
	{
		return sd.deleteCompCategory(login, id, name, description);
	}		
	
	/****************************************************/
	/*  					SERVICES                    */	
	/*  									            */
	/****************************************************/
	
	public JSONObject getListServicesJSON(JQueryDataTableParamModel param,boolean showAll,String state) throws RemoteException, ServiceException 
	{
		JSONObject jsonResponse = new JSONObject();
		Service[] result=null;
		String filter="";
		String cat_name;
		if (param==null) throw new ServiceException("Invalid Session!");
		if (param.sSearch!=null && !"".equals(param.sSearch))
		{
			filter="detailed_info like '%"+param.sSearch+"%' or short_Description like '%"+param.sSearch+"%'";
			if (STATE_ACTIVE.equals(state))
				filter+=" AND Deadline>=Now()";
			else if (STATE_PAST.equals(state))
				filter+=" AND Deadline<Now()";
			else if (STATE_ALWAYS.equals(state))
				filter+=" AND Deadline IS NULL";
		}
		else
		{
			if (STATE_ACTIVE.equals(state))
				filter+=" Deadline>=Now() OR Deadline IS NULL ";
			else if (STATE_PAST.equals(state))
				filter+=" Deadline<Now()";
			else if (STATE_ALWAYS.equals(state))
				filter+=" Deadline IS NULL";			
		}		
		
		int total=0;
		String login="";
		if (!showAll)
			login=param.login;
		if (filter==null||"".equals(filter.trim()))
			total=sd.countServices(login);
		else
			total=sd.countServices(filter,login);
		result=sd.listServices(filter, param.iDisplayStart, param.iDisplayLength,login);
						
		if (!"***".equals(login) && result!=null)
		{
			try {
				jsonResponse.put("iTotalRecords", total ); //El total despues de filtrar
			    jsonResponse.put("iTotalDisplayRecords", total);
			    JSONArray data = new JSONArray();
			    for(Service req : result){
			        JSONArray row = new JSONArray();
			        row.add( "<a href=\"#\" onclick=\"showFormService('"+req.getId()+"');\">"+req.getId()+"</a>");    
			        cat_name=getNameCompCategory(req.getCategory());
			        if (cat_name!=null && !"".equals(cat_name))
			        	row.add(StringEscapeUtils.escapeHtml(cat_name));
			        else
			        	row.add(""+req.getCategory());		        
			        //row.add(StringEscapeUtils.escapeHtml( getNameCompCategory(req.getCategory())));
			        String promoter=this.getDataPromoter(req.getPromoter_id());
			        if (promoter!=null)
			        	row.add(StringEscapeUtils.escapeHtml(promoter));
			        else
			        	row.add(""+req.getPromoter_id());		
			        if (req.getShort_Description()!=null)
			        	row.add(StringEscapeUtils.escapeHtml(req.getShort_Description())); //StringEscapeUtils.escapeHtml(
			        else
			        	row.add("");
			        if (req.getDetailed_info()!=null)
			        	row.add(StringEscapeUtils.escapeHtml(req.getDetailed_info()));
			        else
			        	row.add("");
			        row.add((req.getWhen_c()));
			        row.add((req.getWhere_c()!=null?req.getWhere_c().replace("/","/ "):""));
			        if (req.getDeadline()!=null)
			        	if (req.getDeadline().getTime().getTime()>0)
			        		row.add(df.format(req.getDeadline().getTime()));
			        	else
			        		row.add("No caducity");
			        else
			        	row.add("");
			        row.add(req.getAverage_mark()+"");
			        row.add(req.getVotes()+"");
			        row.add(req.getDistance()+"");
			        row.add(""+ req.getLng());
			        data.add(row);
			    }
				jsonResponse.put("sEcho", param.sEcho);
			    jsonResponse.put("aaData", data);
			} catch (JSONException e) {
			}
			
		}
		else
		{
			jsonResponse.put("iTotalRecords", 0 ); //El total despues de filtrar
		    jsonResponse.put("iTotalDisplayRecords", 0);
		    jsonResponse.put("sEcho", param.sEcho);
			jsonResponse.put("aaData", "[]");
		}
		return jsonResponse;		
	}
	
	public JSONObject getService(String service_id)  throws RemoteException, ServiceException
	{
		Service[] result=null;
		result=sd.listServices("Offer_id="+service_id, 0, 0,"");
		JSONObject jso=new JSONObject();	
		if (result!=null && result.length>0 )
		{
	        JSONArray row = new JSONArray();
	        row.add(result[0].getId());
	        String promoter=this.getDataPromoter(""+result[0].getPromoter_id());
	        if (promoter!=null)
	        	row.add(promoter);
	        else
	        	row.add(result[0].getPromoter_id());
	        
	        row.add(result[0].getCategory());
	        if (result[0].getShort_Description()!=null)
	        	row.add(result[0].getShort_Description());
	        else
	        	row.add("");
	        if (result[0].getDetailed_info()!=null)
	        	row.add(result[0].getDetailed_info());
	        else
	        	row.add("");
	        row.add(result[0].getWhen_c());
	        row.add(result[0].getWhere_c());
	        
	        if (result[0].getDeadline()!=null)
	        	if (result[0].getDeadline().getTime().getTime()>0)
	        		row.add(df.format(result[0].getDeadline().getTime()));
	        	else
	        		row.add("");
	        else
	        	row.add("");

	        row.add(result[0].getAverage_mark());
	        row.add(result[0].getVotes());
	        row.add(result[0].getLng());
	        jso.put("aaData", row);
		}
		else
			throw new ServiceException("service whith id "+service_id+" not found");
		return jso;
	}
			
	
	public int saveService(String login,int idOffer,String category_id, String short_description, String description,String when,String where, String dateTime) throws ServiceException,RemoteException
	{
		Calendar deadline=Calendar.getInstance();
		if (dateTime==null || "".equals(dateTime))
		{			
			deadline.set(1, 0, 1);
			return sd.saveService(login, idOffer, category_id, short_description, description, when, where, deadline);
		}
		else
		{
			
			try {
				deadline.setTime(df.parse(dateTime));
			} catch (ParseException e) {
				throw new ServiceException("Invcalid DateTime. Format must be DD/MM/YYYY");
			}
			return sd.saveService(login, idOffer, category_id, short_description, description, when, where, deadline);
		}
	}
	
	public int deleteService(String login,int service_id)  throws ServiceException,RemoteException
	{
		return sd.deleteService(login, service_id);
	}	
	
	
	/****************************************************/
	/*  					OFFERS                      */	
	/*  									            */
	/****************************************************/
	
	public JSONObject getListOffersJSON(JQueryDataTableParamModel param,boolean showAll,String state) throws RemoteException, ServiceException 
	{
		JSONObject jsonResponse = new JSONObject();
		Offer[] result=null;
		String filter="";
		if (param==null) throw new ServiceException("Invalid Session!");
		if (param.sSearch!=null && !"".equals(param.sSearch))
		{
			filter="detailed_info like '%"+param.sSearch+"%' or short_Description like '%"+param.sSearch+"%'";
			if (STATE_ACTIVE.equals(state))
				filter+=" AND Deadline>=Now()";
			else if (STATE_PAST.equals(state))
				filter+=" AND Deadline<Now()";
			else if (STATE_ALWAYS.equals(state))
				filter+=" AND Deadline IS NULL";
		}
		else
		{
			if (STATE_ACTIVE.equals(state))
				filter+=" Deadline>=Now() OR Deadline IS NULL ";
			else if (STATE_PAST.equals(state))
				filter+=" Deadline<Now()";
			else if (STATE_ALWAYS.equals(state))
				filter+=" Deadline IS NULL";			
		}
		int total=0;
		String login="";
		if (!showAll)
			login=param.login;
		if (filter==null||"".equals(filter.trim()))
			total=sd.countOffers(login);
		else
			total=sd.countOffers(filter,login);
		result=sd.listOffers(filter, param.iDisplayStart, param.iDisplayLength,login);
						
		if (!"***".equals(login) && result!=null)
		{
			try {
				jsonResponse.put("iTotalRecords", total ); //El total despues de filtrar
			    jsonResponse.put("iTotalDisplayRecords", total);
			    JSONArray data = new JSONArray();
			    for(Offer req : result){
			        JSONArray row = new JSONArray();
			        row.add( "<a href=\"#\" onclick=\"showFormOffer('"+req.getOffer_id()+"');\">"+req.getOffer_id()+"</a>");    
			        row.add(""+req.getOffer_type());
			        row.add(""+req.getCategory());
			        row.add(""+req.getPromoter_id());
			        if (req.getShort_Description()!=null)
			        {
			        	row.add(StringEscapeUtils.escapeHtml(req.getShort_Description()));
			        }
			        else
			        	row.add("");
			        if (req.getDetailed_info()!=null)
			        	
			        	row.add(StringEscapeUtils.escapeHtml(req.getDetailed_info()));
			        else
			        	row.add("");
			        if (req.getWhen_offer()!=null)
			        	row.add((req.getWhen_offer()));
			        else
			        	row.add("");
			        row.add((req.getWhere_offer()!=null?req.getWhere_offer().replace("/","/ "):""));
			        if (req.getDeadline()!=null)
			        	if (req.getDeadline().getTime().getTime()>0)
			        		row.add(df.format(req.getDeadline().getTime()));
			        	else
			        		row.add("No caducity");
			        else
			        	row.add("");
			        row.add(req.getOffer_average_mark()+"");
			        row.add(req.getOffer_votes()+"");
			        //row.add(req.getDistance()+"");
			        row.add(""+ req.getLng());
			        data.add(row);
			    }
				jsonResponse.put("sEcho", param.sEcho);
			    jsonResponse.put("aaData", data);
			} catch (JSONException e) {
			}
			
		}
		else
		{
			jsonResponse.put("iTotalRecords", 0 ); //El total despues de filtrar
		    jsonResponse.put("iTotalDisplayRecords", 0);
		    jsonResponse.put("sEcho", param.sEcho);
			jsonResponse.put("aaData", "[]");
		}
		return jsonResponse;		
	}
	
	public JSONObject getOffer(String id)  throws RemoteException, ServiceException
	{
		Offer[] result=null;
		result=sd.listOffers("Offer_id="+id, 0, 0,"");
		JSONObject jso=new JSONObject();	
		if (result!=null && result.length>0 )
		{
	        JSONArray row = new JSONArray();
	        row.add(result[0].getOffer_id());
	        row.add(result[0].getOffer_type());
	        String promoter=this.getDataPromoter(""+result[0].getPromoter_id());
	        if (promoter!=null)
	        	row.add(promoter);
	        else
	        	row.add(result[0].getPromoter_id());
	        row.add(result[0].getRequest_id());
	        row.add(result[0].getCategory());
	        if (result[0].getShort_Description()!=null)
	        {
	        	row.add(result[0].getShort_Description());
	        }
	        else
	        	row.add("");
	        if (result[0].getDetailed_info()!=null)
	        {
	        	row.add(result[0].getDetailed_info());
	        }
	        else
	        	row.add("");
	        if (result[0].getWhen_offer()!=null)
	        	row.add(result[0].getWhen_offer());
	        else
	        	row.add("");
	        row.add(result[0].getWhere_offer());
	        if (result[0].getDeadline()!=null)
	        	if (result[0].getDeadline().getTime().getTime()>0)
	        		row.add(df.format(result[0].getDeadline().getTime()));
	        	else
	        		row.add("");	        
	        else
	        	row.add("");
	        row.add(result[0].getOffer_votes());
	        row.add(result[0].getOffer_average_mark());
	        row.add(result[0].getDistance());
	        jso.put("aaData", row);
			
		}
		else
			throw new ServiceException("offer whith id "+id+" not found");
		return jso;
	}
			
	
	public int saveOffer(String login,int idOffer,String category_id, String short_description, String description,String when,String where, String dateTime) throws ServiceException,RemoteException
	{
		Calendar deadline=Calendar.getInstance();
		if (dateTime==null || "".equals(dateTime))
		{
			Calendar c=Calendar.getInstance();
			c.set(1, 0, 1);
			return sd.saveOffer(login, idOffer, category_id, short_description, description, when, where, c);
		}
		else
		{
			try {
				deadline.setTime(df.parse(dateTime));
			} catch (ParseException e) {
				throw new ServiceException("Invcalid DateTime. Format must be DD/MM/YYYY");
			}
			return sd.saveOffer(login, idOffer, category_id, short_description, description, when, where, deadline);
		}
	}
	
	public int deleteOffer(String login,int offer_id)  throws ServiceException,RemoteException
	{
		return sd.deleteOffer(login, offer_id);
	}	
	
	

	/****************************************************/
	/*  					REQUESTS                    */	
	/*  									            */
	/****************************************************/
/*	
	public JSONObject getListRequestsJSON(JQueryDataTableParamModel param,boolean showAll) throws RemoteException, ServiceException 
	{
		JSONObject jsonResponse = new JSONObject();
		Request[] result=null;
		String[] statuses={ "Error","Submitted","Pending","Pending Approval","Accepted","Closed","Rejected"};

		String filter="";
		if (param==null) throw new ServiceException("Invalid Session!");
		if (param.sSearch!=null && !"".equals(param.sSearch))
		{
			filter="description like '%"+param.sSearch+"%' OR short_description like '%"+param.sSearch+"%' ";
		}
		int total=0;
		String login="";
		if (!showAll)
			login=param.login;
		if (filter==null||"".equals(filter.trim()))
			total=sd.countRequests(login);
		else
			total=sd.countRequests(filter,login);
		result=sd.listRequests(filter, param.iDisplayStart, param.iDisplayLength,login);
						
		if (result!=null)
		{
			try {
				jsonResponse.put("iTotalRecords", total ); //El total despues de filtrar
			    jsonResponse.put("iTotalDisplayRecords", total);
			    JSONArray data = new JSONArray();
			    for(Request req : result){
			        JSONArray row = new JSONArray();
			        row.add( "<a href=\"#\" onclick=\"showFormRequest('"+req.getRequest_id()+"');\">"+req.getRequest_id()+"</a>");
			        row.add(req.getRequester_id());
			        row.add(statuses[req.getStatus()]);
			        row.add(""+req.getRequest_type());
			        row.add(""+req.getCategory_id());
			        if (req.getShort_description()!=null)
			        {
			        	row.add(StringEscapeUtils.escapeHtml(req.getShort_description()));
			        	//row.add(req.getDescription().replaceAll("‡", "&aacute;").replaceAll("Ž", "&eacute;").replaceAll("’", "&iacute;").replaceAll("—", "&oacute;").replaceAll("œ", "&uacute;").replaceAll("–", "&ntilde;"));
			        }
			        else
			        	row.add("");			        
			        if (req.getDescription()!=null)
			        {
			        	row.add(StringEscapeUtils.escapeHtml(req.getDescription()));
			        	//row.add(req.getDescription().replaceAll("‡", "&aacute;").replaceAll("Ž", "&eacute;").replaceAll("’", "&iacute;").replaceAll("—", "&oacute;").replaceAll("œ", "&uacute;").replaceAll("–", "&ntilde;"));
			        }
			        else
			        	row.add("");
			        if (req.getWhen_request()!=null)
			        {
			        	row.add(StringEscapeUtils.escapeHtml(req.getWhen_request()));
			        }
			        else 
			        	row.add("");
			        if (req.getWhere_request()!=null)
			        {
			        	row.add(StringEscapeUtils.escapeHtml(req.getWhere_request().replace("/","/ ")));
			        }
			        else
			        	row.add("");
			        if (req.getDeadline()!=null)
			        	row.add(df.format(req.getDeadline().getTime()));
			        else
			        	row.add("");
			        row.add(req.getDistance()+"");
			        row.add(""+ req.getLng());
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
	
	public JSONObject getRequest(String id)  throws RemoteException, ServiceException
	{
		Request[] result=null;
		result=sd.listRequests("requestId="+id, 0, 0,"");
		JSONObject jso=new JSONObject();	
		if (result!=null && result.length>0 )
		{
	        JSONArray row = new JSONArray();
	        row.add(result[0].getRequest_id());
	        String promoter=this.getDataPromoter(""+result[0].getRequester_id());
	        if (promoter!=null)
	        	row.add(promoter);
	        else
	        	row.add(result[0].getRequester_id());
	        row.add(result[0].getRequest_type());
	        row.add(result[0].getCategory_id());
	        if (result[0].getShort_description()!=null)
	        {
	        	row.add(result[0].getShort_description());
	        	//row.add(result[0].getDescription());
	        }
	        else
	        	row.add("");	        
	        if (result[0].getDescription()!=null)
	        {
	        	row.add(result[0].getDescription());
	        	//row.add(result[0].getDescription());
	        }
	        else
	        	row.add("");
	        row.add(result[0].getWhen_request()==null?"":result[0].getWhen_request());
	        row.add(result[0].getWhere_request()==null?"":result[0].getWhere_request());
	        if (result[0].getDeadline()!=null)
	        	row.add(df.format(result[0].getDeadline().getTime()));
	        else
	        	row.add("");
	        row.add(result[0].getCandidates());
	        row.add(result[0].getFiltering_preferences());
	        row.add(result[0].getStatus());
	        jso.put("aaData", row);
			
		}
		else
			throw new ServiceException("request whith id "+id+" not found");
		return jso;
	}
			
	public int saveRequest(String login,int idRequest,String type, String category_id, String short_description, String description,String when,String where, String dateTime,String candidates,net.i2cat.csade.life2.backoffice.clientws.a.net.i2cat.csade.life2.backoffice.clientws.a.engservice.Status status,net.i2cat.csade.life2.backoffice.clientws.a.net.i2cat.csade.life2.backoffice.clientws.a.engservice.FilteringPrefs fc) throws ServiceException,RemoteException
	{
		try {
			df.parse(dateTime);
		} catch (ParseException e) {
			throw new ServiceException("Invcalid DateTime. Format must be DD/MM/YYYY");
		}
		return sd.saveRequest(login, idRequest, type, category_id, short_description,description, when, where, dateTime, candidates,fc,status);
 
	}
	
	public int deleteRequest(String login,int id,String name, String description)  throws ServiceException,RemoteException
	{
		return sd.deleteRequest(login, id, name, description);
	}	
	*/
	
	/****************************************************/
	/*  					ACTIVITIES                  */	
	/*  									            */
	/****************************************************/
	
	public JSONObject getActivity(String id)  throws RemoteException, ServiceException
	{
		Activity[] result=null;
		result=sd.listActivities("Offer_id="+id, 0, 0,"");
		JSONObject jso=new JSONObject();
		if (result!=null && result.length>0 )
		{
	        JSONArray row = new JSONArray();
	        row.add(result[0].getId());
	        row.add(result[0].getCategory());
	        if (result[0].getShort_Description()!=null)
	        	row.add(result[0].getShort_Description());
	        else
	        	row.add("");
	        if (result[0].getDetailed_info()!=null)
	        	row.add( result[0].getDetailed_info());
	        else
	        	row.add("");
	        row.add(result[0].getWhen_c());
	        row.add(result[0].getWhere_c());
	        if (result[0].getDeadline()!=null)
	        	if (result[0].getDeadline().getTime().getTime()>0)
	        		row.add(df.format(result[0].getDeadline().getTime()));
	        	else
	        		row.add("");
	        else
	        	row.add("");        
	        row.add(df.format(result[0].getDeadline().getTime()));
	        String promoter=this.getDataPromoter(result[0].getPromoter_id());
	        if (promoter!=null)
	        	row.add(promoter);
	        else
	        	row.add(result[0].getPromoter_id());
	        row.add(""+result[0].getAverage_mark());
	        row.add(""+result[0].getVotes());
	        row.add(""+ result[0].getDistance());
	        row.add(""+ result[0].getLng());
	        jso.put("aaData", row);
		}
		else
			throw new ServiceException("category whith id "+id+" not found");
		return jso;
	}
	
	public JSONObject getListActivitiesJSON(JQueryDataTableParamModel param,boolean showAll,String state) throws RemoteException, ServiceException 
	{
		JSONObject jsonResponse = new JSONObject();
		Activity[] result=null;
		String filter="";
		if (param==null) throw new ServiceException("Invalid Session!");
		if (param.sSearch!=null && !"".equals(param.sSearch))
		{
			filter="detailed_info like '%"+param.sSearch+"%' or short_Description like '%"+param.sSearch+"%'";
			if (STATE_ACTIVE.equals(state))
				filter+=" AND Deadline>=Now()";
			else if (STATE_PAST.equals(state))
				filter+=" AND Deadline<Now()";
			else if (STATE_ALWAYS.equals(state))
				filter+=" AND Deadline IS NULL";
		}
		else
		{
			if (STATE_ACTIVE.equals(state))
				filter+=" Deadline>=Now() OR Deadline IS NULL ";
			else if (STATE_PAST.equals(state))
				filter+=" Deadline<Now()";
			else if (STATE_ALWAYS.equals(state))
				filter+=" Deadline IS NULL";			
		}
		int total=0;
		String login="";
		if (!showAll)
			login=param.login;
		if (filter==null||"".equals(filter.trim()))
			total=sd.countActivities("COUNT",login);
		else
			total=sd.countActivities(filter,login);
		result=sd.listActivities(filter, param.iDisplayStart, param.iDisplayLength,login);
						
		if (!"***".equals(login) && result!=null)
		{
			try {
				jsonResponse.put("iTotalRecords", total ); //El total despues de filtrar
			    jsonResponse.put("iTotalDisplayRecords", total);
			    JSONArray data = new JSONArray();
			    for(Activity c : result){
			        JSONArray row = new JSONArray();
			        row.add( "<a href=\"#\" onclick=\"showFormActivity('"+c.getId()+"');\">"+c.getId()+"</a>");
			        row.add(StringEscapeUtils.escapeHtml( getNameActCategory(c.getCategory())));
			        String promoter=this.getDataPromoter(c.getPromoter_id());
			        if (promoter!=null)
			        	row.add(StringEscapeUtils.escapeHtml(promoter));
			        else
			        	row.add(c.getPromoter_id());
			        row.add(""+c.getAverage_mark());
			        if (c.getWhen_c()!=null)
			        {
			        	row.add((c.getWhen_c()));
			        }
			        else
			        	row.add("");
			        row.add((c.getWhere_c()!=null?c.getWhere_c().replace("/","/ "):""));
			        row.add(""+ c.getVotes());
			        //row.add(""+ c.getDistance());
			        if (c.getShort_Description()!=null)
			        {
			        	row.add(StringEscapeUtils.escapeHtml(c.getShort_Description())); //StringEscapeUtils.escapeHtml
			        	//row.add(c.getShort_Description().replaceAll("‡", "&aacute;").replaceAll("Ž", "&eacute;").replaceAll("’", "&iacute;").replaceAll("—", "&oacute;").replaceAll("œ", "&uacute;").replaceAll("–", "&ntilde;"));
			        }
			        else
			        	row.add("");
			        if (c.getDetailed_info()!=null)
			        {
			        	row.add(StringEscapeUtils.escapeHtml(c.getDetailed_info())); //StringEscapeUtils.escapeHtml
			        	//row.add(c.getDetailed_info().replaceAll("‡", "&aacute;").replaceAll("Ž", "&eacute;").replaceAll("’", "&iacute;").replaceAll("—", "&oacute;").replaceAll("œ", "&uacute;").replaceAll("–", "&ntilde;"));
			        }
			        else
			        	row.add("");
			        if (c.getDeadline()!=null)
			        	if (c.getDeadline().getTime().getTime()>0)
			        		row.add(df.format(c.getDeadline().getTime()));
			        	else
			        		row.add("No caducity");
			        else
			        	row.add("");
			        row.add(""+ c.getLng());
			        data.add(row);
			    }
				jsonResponse.put("sEcho", param.sEcho);
			    jsonResponse.put("aaData", data);
			} catch (JSONException e) {
			}
			
		}
		else
		{
			jsonResponse.put("iTotalRecords", 0 ); //El total despues de filtrar
		    jsonResponse.put("iTotalDisplayRecords", 0);
		    jsonResponse.put("sEcho", param.sEcho);
			jsonResponse.put("aaData", "[]");
		}
		return jsonResponse;		
	}
	
	public int saveActivity(String login,int id,String category, String short_desc,String detailed_info, String when_Activity, String where_Activity, String strDeadline) throws ServiceException,RemoteException
	{
		Calendar deadline= Calendar.getInstance();
		try {
			deadline.setTime(df.parse(strDeadline));
		} catch (ParseException e) {
		}
		return sd.saveActivity(login, id, category, short_desc, detailed_info, when_Activity, where_Activity, deadline);
	}
	
	public int deleteActivity(String login,int id)  throws ServiceException,RemoteException
	{
		return sd.deleteActivity(login, id);
	}

	/****************************************************/
	/*  					SKILLS                      */	
	/*  									            */
	/****************************************************/
		
	public JSONObject getListSkillsJSON(JQueryDataTableParamModel param,boolean showAll) throws RemoteException, ServiceException 
	{
		JSONObject jsonResponse = new JSONObject();
		Skill[] result=null;
		String filter="";
		if (param==null) throw new ServiceException("Invalid Session!");
		if (param.sSearch!=null && !"".equals(param.sSearch))
		{
			filter="skill_name like '%"+param.sSearch+"%' ";
		}
		int total=0;
		String login="";
		if (!showAll)
			login=param.login;
		if (filter==null||"".equals(filter.trim()))
			total=sd.countSkills("COUNT",login);
		else
			total=sd.countSkills(filter,login);
		result=sd.listSkills(filter, param.iDisplayStart, param.iDisplayLength,login);
						
		if (!"***".equals(login) && result!=null)
		{
			try {
				jsonResponse.put("iTotalRecords", total ); //El total despues de filtrar
			    jsonResponse.put("iTotalDisplayRecords", total);
			    JSONArray data = new JSONArray();
			    for(Skill c : result){
			        JSONArray row = new JSONArray();
			        row.add( "<a href=\"#\" onclick=\"showFormSkill('"+c.getSkill_id()+"');\">"+c.getSkill_id()+"</a>");
			        row.add(StringEscapeUtils.escapeHtml(c.getSkill_name()));
			        row.add(c.getPromoter_id());
			        row.add(""+c.getDistance());
			        row.add(""+ c.getLng());
			        data.add(row);
			    }
				jsonResponse.put("sEcho", param.sEcho);
			    jsonResponse.put("aaData", data);
			} catch (JSONException e) {
			}
			
		}
		else
		{
			jsonResponse.put("iTotalRecords", 0 ); //El total despues de filtrar
		    jsonResponse.put("iTotalDisplayRecords", 0);
		    jsonResponse.put("sEcho", param.sEcho);
			jsonResponse.put("aaData", "[]");
		}
		return jsonResponse;		
	}

	public JSONObject getSkill(String skill_id)  throws RemoteException, ServiceException
	{
		Skill[] result=null;
		result=sd.listSkills("Skill_id="+skill_id, 0, 0,"");
		JSONObject jso=new JSONObject();
		String promoter;
		if (result!=null && result.length>0 )
		{
	        JSONArray row = new JSONArray();
	        row.add(result[0].getSkill_id());
	        row.add(result[0].getSkill_name());
	        promoter=this.getDataPromoter(result[0].getPromoter_id());
	        if (promoter!=null)
	        	row.add(promoter);
	        else
	        	row.add(result[0].getPromoter_id());
	        row.add(""+ result[0].getDistance());
	        row.add(""+ result[0].getLng());
	        jso.put("aaData", row);
		}
		else
			throw new ServiceException("skill whith id "+skill_id+" not found");
		return jso;
	}
	
	
	public int saveSkill(String login,int skill_id, String skill) throws ServiceException,RemoteException
	{
		return sd.saveSkill(login, skill_id, skill) ;
	}
	
	public int deleteSkill(String login,int skill_id)  throws ServiceException,RemoteException
	{
		return sd.deleteSkill(login, skill_id);
	}
	
	/****************************************************/
	/*  					REGIONS                     */	
	/*  									            */
	/****************************************************/
	
	public JSONObject getListSupraregions(String login,String country) throws RemoteException, ServiceException 
	{
		JSONObject jsonResponse = new JSONObject();
		Regions[] result=null;
		String filter="";
		if (country!=null && !"".equals(country))
			filter="country_code like '%"+country+"%' ";
		result=sd.listRegions(filter, 0, Integer.MAX_VALUE,login);
		
		if (result!=null)
		{
			try {
			    JSONArray data = new JSONArray();
			    for(Regions c : result){			   
			        if (c.getSupraRegion()!=null && !data.contains(c.getSupraRegion()))
			        {
			        	data.add(c.getSupraRegion());
			        	jsonResponse.put("aaData", data);
			        }
			    }
			    
			} catch (JSONException e) {
			}
			
		}
		else
		{
			jsonResponse.put("aaData", "[]");
		}
		return jsonResponse;		
	}
	
	
	public JSONObject getListRegionsCountry(String login,String country) throws RemoteException, ServiceException 
	{
		JSONObject jsonResponse = new JSONObject();
		Regions[] result=null;
		String filter="";
		if (country!=null && !"".equals(country))
			filter="country_code like '%"+country+"%' ";
		result=sd.listRegions(filter, 0, Integer.MAX_VALUE,login);
		
		if (result!=null)
		{
			try {
			    JSONArray data = new JSONArray();
			    for(Regions c : result){	
			    	JSONArray row = new JSONArray();
			    	row.add(""+c.getId());
		        	row.add(StringEscapeUtils.escapeHtml(c.getName()));
		        	data.add(row);       	
			    }
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
	
	public JSONObject getListRegionsJSON(JQueryDataTableParamModel param,boolean showAll) throws RemoteException, ServiceException 
	{
		return getListRegionsJSON( param,"", "",showAll);
	}
	
	public JSONObject getListRegionsJSON(JQueryDataTableParamModel param,String supraregion,String country,boolean showAll) throws RemoteException, ServiceException 
	{
		JSONObject jsonResponse = new JSONObject();
		Regions[] result=null;
		String filter="";
		Hashtable<String,String> countries=new Hashtable<String,String>();
		
		countries.put("AT","Austria");
		countries.put("BEL","Belgium");
		countries.put("BGR","Bulgaria");
		countries.put("CYP","Cyprus");
		countries.put("CZE","Czech Republic");
		countries.put("DNK","Denmark");
		countries.put("EST","Estonia");
		countries.put("FIN","Finland");
		countries.put("FRA","France");
		countries.put("DEU","Germany");
		countries.put("GBR","Great Britain");
		countries.put("GRC","Greece");
		countries.put("HUN","Hungary");
		countries.put("IRL","Ireland");
		countries.put("ITA","Italy");
		countries.put("LVA","Latvia");
		countries.put("LTU","Lithuania");
		countries.put("LUX","Luxembourg");
		countries.put("MLT","Malta");
		countries.put("NLD","Netherlands");
		countries.put("POL","Poland");
		countries.put("PRT","Portugal");
		countries.put("ROU","Romania");
		countries.put("SVK","Slovakia");
		countries.put("SVN","Slovenia");
		countries.put("ESP","Spain");
		countries.put("SWE","Sweden");
		
		if (param==null) throw new ServiceException("Invalid Session!");
		if (param.sSearch!=null && !"".equals(param.sSearch))
		{
			filter="name like '%"+param.sSearch+"%' ";
		}
		if (supraregion!=null && !"".equals(supraregion))
		{
			filter="supraRegion like '%"+supraregion+"%'";
		}
		if (country!=null && !"".equals(country))
		{
			filter="country_code like '%"+country+"%'";
		}		
		int total=0;
		String login="";
		if (!showAll)
			login=param.login;
		if (filter==null||"".equals(filter.trim()))
			total=sd.countRegions(login);
		else
			total=sd.countRegions(login,filter);
		result=sd.listRegions(filter, param.iDisplayStart, param.iDisplayLength,login);
						
		if (result!=null)
		{
			try {
				jsonResponse.put("iTotalRecords", total ); //El total despues de filtrar
			    jsonResponse.put("iTotalDisplayRecords", total);
			    JSONArray data = new JSONArray();
			    for(Regions c : result){
			        JSONArray row = new JSONArray();
			        row.add( "<a href=\"#\" onclick=\"showFormRegion('"+c.getId()+"');\">"+c.getId()+"</a>");
			        row.add(StringEscapeUtils.escapeHtml(c.getName())); //StringEscapeUtils.escapeHtml(
			        row.add(StringEscapeUtils.escapeHtml(c.getSupraRegion())); 
			        row.add(StringEscapeUtils.escapeHtml(countries.containsKey(c.getCountry())?countries.get(c.getCountry()):c.getCountry()));
			        row.add(""+c.getRadius());
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

	public JSONObject getRegion(String region_id)  throws RemoteException, ServiceException
	{
		Regions[] result=null;
		result=sd.listRegions("id="+region_id, 0, 0,"");
		JSONObject jso=new JSONObject();
		if (result!=null && result.length>0 )
		{
	        JSONArray row = new JSONArray();
	        row.add(result[0].getId());
	        row.add(result[0].getName());
	        row.add(result[0].getSupraRegion());
	        row.add(result[0].getCountry());
	        row.add(""+ result[0].getRadius());
	        row.add(""+ result[0].getLng());
	        row.add(""+ result[0].getLat());
	        row.add(""+ result[0].getLon());
	        jso.put("aaData", row);
		}
		else
			throw new ServiceException("region whith id "+region_id+" not found");
		return jso;
	}
	
	public int saveRegion(String login,int region_id, String name,String lat,String lon,String supra_region, String country,String country_code,String lng,int radius) throws ServiceException,RemoteException
	{
		
		return sd.saveRegion(login, name, region_id, lat, lon,supra_region,country_code,country_code,lng, radius) ;
	}
	
	public int deleteRegion(String login,int region_id)  throws ServiceException,RemoteException
	{
		return sd.deleteRegion(login, region_id);
	}	
	
	
	
	/*************************** CONTADORES ***************************/
	public String getPlatformData(String type) {
		JSONObject jso=new JSONObject();
		String result="";
		PlatformUserDAO ud=new PlatformUserDAO();
		int total_offers=0;
		int total_requests=0;
		int total_services=0;
		int total_activities=0;
		int total_activeusers=0;
		int total_user=0;
		int total_hub=0;
		int total_sb=0;
		int total_bb=0;
		int total_area_m=0;
		int total_sysadm=0;
		int total_region=0;
		int total_country=0;
		int total_demo=0;
		try {
			total_offers=sd.countOffers("");
			total_requests=sd.countRequests("");
			total_services=sd.countServices("");
			total_activities = sd.countActivities("");
			total_activeusers=ud.countPlatformUsersFiltered("Enabled=1");
			total_user=ud.countPlatformUsersFiltered("Enabled=1 AND Role="+PlatformUser.ROLE_USER);
			total_hub=ud.countPlatformUsersFiltered("Enabled=1 AND Role="+PlatformUser.ROLE_HUB);
			total_sb=ud.countPlatformUsersFiltered("Enabled=1 AND Role="+PlatformUser.ROLE_BUSINESS);
			total_bb=ud.countPlatformUsersFiltered("Enabled=1 AND Role="+PlatformUser.ROLE_BIG_BUSINESS);
			total_area_m=ud.countPlatformUsersFiltered("Enabled=1 AND Role="+PlatformUser.ROLE_AREA_MANAGER);
			total_sysadm=ud.countPlatformUsersFiltered("Enabled=1 AND Role="+PlatformUser.ROLE_SYSTEM_ADMIN);;
			total_region=ud.countPlatformUsersFiltered("Enabled=1 AND Role="+PlatformUser.ROLE_REGION_ADMIN);
			total_country=ud.countPlatformUsersFiltered("Enabled=1 AND Role="+PlatformUser.ROLE_COUNTRY_ADMIN);
			total_demo=ud.countPlatformUsersFiltered("Enabled=1 AND Role="+PlatformUser.ROLE_DEMO_USER);
			
		} catch (RemoteException e) {
		} catch (ServiceException e) {

		}
		if (type==null)
		{
			JSONArray row = new JSONArray();
		    row.add(""+total_offers);
		    row.add(total_requests);
		    row.add(""+total_services);
		    row.add(total_activities);
		    row.add(total_activeusers);
		    row.add(total_user);
		    row.add(total_hub);
		    row.add(total_sb);
		    row.add(total_bb);
		    row.add(total_area_m);
		    row.add(total_sysadm);
		    row.add(total_region);
		    row.add(total_country);
		    row.add(total_demo);
		    jso.put("aaData", row);
		    result=jso.toString();   
		}
		else
		{
			result= "Active Users,"+total_activeusers+"\nTotal Offers,"+total_offers+"\nTotal Requests,"+total_requests+"\nTotal Services,"+total_services+"\nTotal Activities,"+total_activities;
		}
		return result;
}
	/*************************** UTILIDADES ***************************/
	public String getDataPromoter(String strPromoter)
	{
		ObjStats[] st=null;
		ArrayList<Pair> datos=new ArrayList<Pair>();
		String result=null;
		try {
			int idPromoter=Integer.parseInt(strPromoter);
			String sql="SELECT User_id as idStat,Role as Event,Login as user_Login,Last_loc_timestamp as dTime,0 as duration,\"\" as lat,\"\" as lon,Name as device,Name as query,0 as lng FROM user_profile WHERE User_id="+idPromoter;

			st=sd.listStatsSQL(sql);
		} catch (RemoteException e) {
			e.printStackTrace();
		} catch (ServiceException e) {	
			e.printStackTrace();
		}catch (NumberFormatException e) {	
			e.printStackTrace();
		}
		if (st!=null && st.length>0)
		{
			result=st[0].getUser_Login();
			if (st[0].getQuery()!=null)
				result=result+" ("+StringEscapeUtils.escapeHtml(st[0].getQuery())+")";
		}	
		else
		{
			result="(Not available)";
		}
		return result;
	}
	
	public String getNameCategory(String strPromoter)
	{
		ObjStats[] st=null;
		String result=strPromoter;
		try {
			int idPromoter=Integer.parseInt(strPromoter);
			String sql="SELECT 0 as idStat,0 as Event,Category_name as User_login,null as dTime,0 as duration,\"\" as lat,\"\" as lon,\"\" as device,Category_description as query,0 as lng FROM category WHERE Category_id="+idPromoter;
			st=sd.listStatsSQL(sql);
		} catch (RemoteException e) {
		} catch (ServiceException e) {	
		}catch (NumberFormatException e) {	
		}
		if (st!=null && st.length>0)
		{
			result=(st[0].getUser_Login());
		}	
		return result;
	}
	
	public String getNameActCategory(String strPromoter)
	{
		ObjStats[] st=null;
		String result=strPromoter;
		try {
			int idPromoter=Integer.parseInt(strPromoter);
			String sql="SELECT 0 as idStat,0 as Event,Category_name as User_login,null as dTime,0 as duration,\"\" as lat,\"\" as lon,\"\" as device,Category_description as query,0 as lng FROM activity_category WHERE Category_id="+idPromoter;
			st=sd.listStatsSQL(sql);
		} catch (RemoteException e) {
		} catch (ServiceException e) {	
		}catch (NumberFormatException e) {	
		}
		if (st!=null && st.length>0)
		{
			result=(st[0].getUser_Login());
		}	
		return result;
	}	
	
	public String getNameCompCategory(String strPromoter)
	{
		ObjStats[] st=null;
		String result=strPromoter;
		try {
			int idPromoter=Integer.parseInt(strPromoter);
			String sql="SELECT 0 as idStat,0 as Event,Category_name as User_login,null as dTime,0 as duration,\"\" as lat,\"\" as lon,\"\" as device,Category_description as query,0 as lng FROM company_category WHERE Category_id="+idPromoter;
			st=sd.listStatsSQL(sql);
		} catch (RemoteException e) {
		} catch (ServiceException e) {	
		}catch (NumberFormatException e) {	
		}
		if (st!=null && st.length>0)
		{
			result=(st[0].getUser_Login());
		}	
		return result;
	}	
	
	/********************* PRIVATE**********************************/
	
	private String weDontSpeakAmericano(String europeanDate)
	{
		String ret="";
		try {
			SimpleDateFormat americano=new SimpleDateFormat("MM/dd/yyyy");
			ret=americano.format(df.parse(europeanDate));
		} catch (ParseException e) {
			ret="";
		}
		return ret;
	}
	
}

/* Life 2.0 Backoffice code Copyright (C) 2014 - Fundació i2CAT This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA. */

package net.i2cat.csade.life2.backoffice.DAO;

import java.rmi.RemoteException;
import javax.xml.rpc.ServiceException;
import javax.xml.rpc.holders.IntHolder;
import javax.xml.rpc.holders.StringHolder;
import net.i2cat.csade.life2.backoffice.model.PlatformUser;
import net.i2cat.csade.life2.backoffice.clientws.b.dbservice.DBServiceLocator;
import net.i2cat.csade.life2.backoffice.clientws.b.dbservice.UserProfile;
import net.i2cat.csade.life2.backoffice.clientws.b.dbservice.holders.*;

public class PlatformUserDAO {
	
	public PlatformUser get(String login) throws ServiceException,RemoteException {

		DBServiceLocator ds=new DBServiceLocator();
		
		javax.xml.rpc.holders.IntHolder role = new javax.xml.rpc.holders.IntHolder();
		javax.xml.rpc.holders.IntHolder region = new javax.xml.rpc.holders.IntHolder();
		javax.xml.rpc.holders.IntHolder enabled = new javax.xml.rpc.holders.IntHolder();
		javax.xml.rpc.holders.IntHolder interestsVisibility = new javax.xml.rpc.holders.IntHolder();
		javax.xml.rpc.holders.IntHolder skillsVisibility = new javax.xml.rpc.holders.IntHolder();
		javax.xml.rpc.holders.StringHolder email = new javax.xml.rpc.holders.StringHolder();
		javax.xml.rpc.holders.StringHolder name = new javax.xml.rpc.holders.StringHolder();
		javax.xml.rpc.holders.StringHolder picture= new javax.xml.rpc.holders.StringHolder();
		javax.xml.rpc.holders.StringHolder language= new javax.xml.rpc.holders.StringHolder();
		javax.xml.rpc.holders.StringHolder home_area_lat= new javax.xml.rpc.holders.StringHolder();
		javax.xml.rpc.holders.StringHolder home_area_lon= new javax.xml.rpc.holders.StringHolder();
		javax.xml.rpc.holders.StringHolder last_location_timestamp= new javax.xml.rpc.holders.StringHolder();
		javax.xml.rpc.holders.StringHolder last_location_lat= new javax.xml.rpc.holders.StringHolder();
		javax.xml.rpc.holders.StringHolder last_location_lon= new javax.xml.rpc.holders.StringHolder();
		javax.xml.rpc.holders.StringHolder notification_level= new javax.xml.rpc.holders.StringHolder();
		javax.xml.rpc.holders.StringHolder promoter_id= new javax.xml.rpc.holders.StringHolder();
		javax.xml.rpc.holders.StringHolder user_average_mark= new javax.xml.rpc.holders.StringHolder();
		javax.xml.rpc.holders.StringHolder user_votes= new javax.xml.rpc.holders.StringHolder();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		javax.xml.rpc.holders.StringHolder telephonenumber= new javax.xml.rpc.holders.StringHolder();
		javax.xml.rpc.holders.StringHolder home_area_radius= new javax.xml.rpc.holders.StringHolder();
		javax.xml.rpc.holders.StringHolder address= new javax.xml.rpc.holders.StringHolder();
		
		@SuppressWarnings("unused")
		int res=ds.getDBServiceSoap().dbReadUser(login, role, email, name, picture, language, telephonenumber, home_area_lat, home_area_lon, home_area_radius, last_location_timestamp, last_location_lat, last_location_lon, notification_level, promoter_id, user_average_mark, user_votes, enabled, region,address,  skillsVisibility,interestsVisibility, errorMessage);
				
				
				//.dbReadUser(login, role, email, name, picture, language, home_area_lat, home_area_lon, last_location_timestamp, last_location_lat, last_location_lon, notification_level, promoter_id, user_average_mark, user_votes, enabled, errorMessage);
		
		PlatformUser user=new PlatformUser();
		user.setLogin(login);
		user.setRole(role.value);
		/*if (login.startsWith("J"))
		{
			String test=StringEscapeUtils.unescapeJava(login);
			String test2=PasswordGenerator.utf8Decoder(login);
			String test3=PasswordGenerator.isoDecoder(login);
			String test4=PasswordGenerator.isoEncoder(login);
			String test5=PasswordGenerator.utf8Encoder(login);
			user.setLogin(login);
		}*/
		user.setEmail(email.value);
		user.setPicture(picture.value);
		user.setName(name.value);
		user.setLanguage(language.value);
		user.setTelephonenumber(telephonenumber.value);
		user.setHome_area_lat(home_area_lat.value);
		user.setHome_area_lon(home_area_lon.value);
		user.setHome_area_rad(home_area_radius.value);
		user.setLast_location_timestamp(last_location_timestamp.value);
		user.setLast_location_lat(last_location_lat.value);
		user.setLast_location_lon(last_location_lon.value);
		user.setNotification_level(notification_level.value);
		user.setPromoter_id(promoter_id.value);
		user.setUser_average_mark(user_average_mark.value);
		user.setUser_votes(user_votes.value);
		user.setEnabled(enabled.value);
		user.setNew(false);
		user.setRegion(region.value);
		user.setAddress(address.value);
		return user;
	
	}

	public UserProfile[] getPlatformUsersFiltered(String filter,int start,int count) throws RemoteException, ServiceException
	{
		UserProfile[] result=null;
		DBServiceLocator ds=new DBServiceLocator();
		StringHolder errorMessage = new StringHolder();
		ArrayOfUserProfileHolder ret_UserList=new ArrayOfUserProfileHolder();
		IntHolder it=new IntHolder();
		it.value=count;
		int res=ds.getDBServiceSoap().getUserList(filter, ret_UserList, start, count, "", errorMessage);
				//getUserList(filter, ret_UserList, start, count, "", errorMessage);
		result=ret_UserList.value;
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"getPlatformUsersFiltered ha dado error sin dar mas informaci—n":errorMessage.value);
		return result;
}
	
	public int countPlatformUsersFiltered(String filter) throws RemoteException, ServiceException
	{
		String filt="";
		DBServiceLocator ds=new DBServiceLocator();
		StringHolder errorMessage = new StringHolder();
		ArrayOfUserProfileHolder ret_UserList=new ArrayOfUserProfileHolder();
		if ("".equals(filter))
			filt="count user_votes>=0 or user_votes is null";
		else
			filt="count "+filter;
		int res=ds.getDBServiceSoap().getUserList(filt, ret_UserList, 0, 0, "",errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"countPlatformUsersFiltered ha dado error sin dar mas informaci—n":errorMessage.value);
		return res;
}

	public int delete(String login ) throws ServiceException, RemoteException {
		DBServiceLocator ds=new DBServiceLocator();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		int res=0;	
		res=ds.getDBServiceSoap().dbDeleteUser(login, errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"Delete user devolvi— un error sin especificar":errorMessage.value);
		return res;
	}
	
public int insert(PlatformUser user) throws ServiceException, RemoteException {
	DBServiceLocator ds=new DBServiceLocator();
	int res=0;
	javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
	
	if (user.isNew())
	{
		res=ds.getDBServiceSoap().dbRegisterUser(user.getLogin(), ""+user.getRole(), user.getPass(), user.getName(), user.getEmail(), user.getTelephonenumber(),user.getLanguage(), user.getHome_area_lat()==null?"41,38792":user.getHome_area_lat(), user.getHome_area_lon()==null?"2,16992":user.getHome_area_lon(), user.getHome_area_rad(), user.getNotification_level(), user.getRegion(), errorMessage);
				//.dbRegisterUser(user.getLogin(), ""+user.getRole(), user.getPass(), user.getName(), user.getEmail(), user.getLanguage(), user.getHome_area_lat()==null?"41,38792":user.getHome_area_lat(), user.getHome_area_lon()==null?"2,16992":user.getHome_area_lon(), user.getNotification_level(), errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"dbRegisterUser returned an unespecified error":errorMessage.value);

	}
	else
	{
		int  skillsVisibility=0;
		int interestsVisibility=0;
		res=ds.getDBServiceSoap().dbUpdateUser( user.getLogin(), ""+user.getRole(), user.getPass(), user.getName(), user.getEmail(), user.getTelephonenumber(),user.getPicture(), user.getLanguage(), user.getHome_area_lat(), user.getHome_area_lon(), user.getLast_location_timestamp(), user.getLast_location_lat(), user.getLast_location_lon(),user.getHome_area_rad(),  user.getNotification_level(),user.getPromoter_id(), user.getUser_average_mark(), user.getUser_votes(), user.getEnabled(), skillsVisibility, interestsVisibility, user.getRegion(), user.getAddress(), errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"dbUpdateUser returned an unespecified error":errorMessage.value);
	}
	return res;
}

	
public int uploadPicture(String login,byte[] picture ) throws ServiceException,RemoteException
{
	DBServiceLocator ds=new DBServiceLocator();
	int res=0;
	javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
	
	res=ds.getDBServiceSoap().uploadPicture(login, picture, errorMessage);
	if (res<0)
		throw new ServiceException(errorMessage.value==null?"uploadPicture returned an unespecified error":errorMessage.value);
	return res;
}

public int login(String login,String password ) throws ServiceException,RemoteException
{
	DBServiceLocator ds=new DBServiceLocator();
	int res=0;
	javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
	javax.xml.rpc.holders.StringHolder text= new javax.xml.rpc.holders.StringHolder();
	IntHolder ih=new IntHolder();
	IntHolder region=new IntHolder();
	IntHolder enabled=new IntHolder();
	res=ds.getDBServiceSoap().dbUserLogin(login, password, ih, text, text, text, text, text, text, text, text, text, text, text, text, text, text, text, enabled, region, errorMessage);
	if (res<0)
		throw new ServiceException(errorMessage.value==null?"login returned an unespecified error":errorMessage.value);
	if (enabled.value==0)
		throw new ServiceException("Login not successful because user is not enabled");
	return res;
}
	

}
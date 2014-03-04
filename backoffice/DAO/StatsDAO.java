/* Life 2.0 Backoffice code Copyright (C) 2014 - Fundació i2CAT This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA. */

package net.i2cat.csade.life2.backoffice.DAO;

import java.rmi.RemoteException;
import java.util.Calendar;

import javax.xml.rpc.ServiceException;
import javax.xml.rpc.holders.IntHolder;

import net.i2cat.csade.life2.backoffice.clientws.b.engservice.Activity;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.Category;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.ENGServiceLocator;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.FilteringPrefs;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.ObjStats;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.Offer;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.Request;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.Service;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.Skill;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.Stats;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.Status;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.holders.*;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.Regions;

public class StatsDAO {
	
	public static final int USER_ADDED=1;
	public static final int LOGIN_EVENT=2;
	//public static final int LOGOUT_EVENT=2;

	public static final int USER_DELETED=4;
	
	public static final int TEST_EVENT=23;
	/*
	 *   "RegisterUser" = "1"
                "UserLogin" = "2"
                "UpdateUser" = "3"
                "DeleteUser" = "4"
                "ReadUser" = "5"
                "UserList" = "6"
                "UploadPicture" = "7"
                "AcceptRejectNewCategory" = "8"
                "AcceptRejectRequest" = "9"
                "AddActivity" = "10"
                "AddCategory" = "11"
                "AddService" = "12"
                "AddSkill" = "13"
                "ApplyForOffer" = "14"
                "ApplyForRequest" = "15"
                "DeleteActivity" = "16"
                "DeleteCategory" = "17"
                "DeleteOffer" = "18"
                "DeleteRecommendation" = "19"
                "DeleteRequest" = "20"
                "DeleteService" = "21"
                "DeleteSkill" = "22"
                "GetActivities" = "23"
                "GetCategories" = "24"
                "GetOffer" = "25"
                "GetRecommendations" = "26"
                "GetRequests" = "27"
                "GetRequestStatus" = "28"
                "GetServices" = "29"
                "GetSkills" = "30"
                "GetStats" = "31"
                "GetStatsSql" = "32"
                "JoinActivity" = "33"
                "ModerateJoinActivity" = "34"
                "PromoterFeedback" = "35"
                "SendFeedback" = "36"
                "SendRecommendation" = "37"
                "SubmitOffer" = "38"
                "SubmitRequest" = "39"
                "UnApplyForOffer" = "40"
                "UnApplyForRequest" = "41"
                "UnJoinActivity" = "42"
                "UpdateActivity" = "43"
                "UpdateCategory" = "44"
                "UpdateOffer" = "45"
                "UpdateRequest" = "46"
                "UpdateService" = "47"
                "UpdateSkill" = "48"

	 */
	
	
	/********** ACTIVITIES **********************/
	public int countActivities(String username) throws ServiceException,RemoteException {
		return countActivities("COUNT",username);
	}
	public int countActivities(String filter,String username) throws ServiceException,RemoteException {
		ArrayOfActivityHolder ret_Activities=new ArrayOfActivityHolder();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		String strFilter=filter;
		ENGServiceLocator es=new ENGServiceLocator();
		if (!filter.toLowerCase().contains("count"))
			strFilter="COUNT "+filter;
		int res=es.getENGServiceSoap().getActivities(strFilter, ret_Activities, 0, 0, username,errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"countActivities ha dado error sin dar mas informaci—n. Filter:"+strFilter:errorMessage.value);
		return res;	
	}
	
	public Activity[] listActivities(String filter,int start,int count,String username) throws ServiceException,RemoteException {
		ArrayOfActivityHolder ret_Activities=new ArrayOfActivityHolder();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		ENGServiceLocator es=new ENGServiceLocator();
		int res=es.getENGServiceSoap().getActivities(filter, ret_Activities, start, count,username, errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"listActivities ha dado error sin dar mas informaci—n":errorMessage.value);
		return ret_Activities.value;	
	}
	
	public int saveActivity(String login,int id,String category, String short_desc, String detailed_info, String when_Activity, String where_Activity, Calendar deadline) throws ServiceException,RemoteException
	{
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		ENGServiceLocator es=new ENGServiceLocator();
		int res=0;
		if (id>0) {
			res=es.getENGServiceSoap().updateActivity(login, id, category, short_desc, detailed_info, when_Activity, where_Activity, deadline, 0, "", "", deadline, "", "", "", 0, Integer.MAX_VALUE, errorMessage);
					//.updateActivity(login, id, category, short_desc, detailed_info, when_Activity, where_Activity, deadline, errorMessage);
		}
		else
		{
			res=es.getENGServiceSoap().addActivity(login, category, short_desc, detailed_info, when_Activity, where_Activity, deadline, 0, "", "",deadline, "", "", "", 0, Integer.MAX_VALUE, errorMessage);
					//.addActivity(login, category, short_desc, detailed_info, when_Activity, where_Activity, deadline, errorMessage);
		}
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"saveActivity ha dado error sin dar mas informaci—n":errorMessage.value);
		return res;			
	}
	
	public int deleteActivity(String login,int id) throws ServiceException,RemoteException
	{
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		ENGServiceLocator es=new ENGServiceLocator();
		int res=0;
		if (id>0) {
			res=es.getENGServiceSoap().deleteActivity(login,id, errorMessage);
		}
		return res;			
	}
	
	/********** CATEGORIES **********************/
	public int countCategories(String username) throws ServiceException,RemoteException {
		return countCategories("COUNT",username);
	}
	
	public int countCategories(String filter,String username) throws ServiceException,RemoteException {
		ArrayOfCategoryHolder ret_categories=new ArrayOfCategoryHolder();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		String strFilter=filter;
		ENGServiceLocator es=new ENGServiceLocator();
		if (!filter.toLowerCase().contains("count"))
			strFilter=" COUNT "+filter;
		int res=es.getENGServiceSoap().getCategories(strFilter, ret_categories, 0, 0, username,errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"countCategories ha dado error sin dar mas informaci—n.Filter:"+strFilter:errorMessage.value);
		return res;		
	}
	
	public Category[] listCategories(String filter,int start,int count,String username) throws ServiceException,RemoteException {
		ArrayOfCategoryHolder ret_categories=new ArrayOfCategoryHolder();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		IntHolder ih=new IntHolder();
		ih.value=count;
		ENGServiceLocator es=new ENGServiceLocator();
		int res=es.getENGServiceSoap().getCategories(filter, ret_categories, start, count, username, errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"listCategories ha dado error sin dar mas informaci—n":errorMessage.value);
		return ret_categories.value;	
	}
	
	public int saveCategory(String login,int id,String name,int status, String description) throws ServiceException,RemoteException
	{
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		ENGServiceLocator es=new ENGServiceLocator();
		int res=0;
		if (id>0) {
			res=es.getENGServiceSoap().updateCategory(login, id+"", name, description,status, errorMessage);
		}
		else
		{
			res=es.getENGServiceSoap().addCategory(login, name, description, errorMessage);
		}
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"saveCategory ha dado error sin dar mas informaci—n":errorMessage.value);
		return res;			
	}
	
	public int deleteCategory(String login,int id,String name, String description) throws ServiceException,RemoteException
	{
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		ENGServiceLocator es=new ENGServiceLocator();
		int res=0;
		if (id>0) {
			res=es.getENGServiceSoap().deleteCategory(login, ""+id, errorMessage);
		}
		return res;			
	}

	/********** ACTIVITY CATEGORIES **********************/
	public int countActCategories(String username) throws ServiceException,RemoteException {
		return countActCategories("COUNT",username);
	}
	
	public int countActCategories(String filter,String username) throws ServiceException,RemoteException {
		ArrayOfCategoryHolder ret_categories=new ArrayOfCategoryHolder();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		String strFilter=filter;
		ENGServiceLocator es=new ENGServiceLocator();
		if (!filter.toLowerCase().contains("count"))
			strFilter=" COUNT "+filter;
		int res=es.getENGServiceSoap().getActCategories(strFilter, ret_categories, 0, 0, username,errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"countActCategories ha dado error sin dar mas informaci—n.Filter:"+strFilter:errorMessage.value);
		return res;		
	}
	
	public Category[] listActCategories(String filter,int start,int count,String username) throws ServiceException,RemoteException {
		ArrayOfCategoryHolder ret_categories=new ArrayOfCategoryHolder();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		IntHolder ih=new IntHolder();
		ih.value=count;
		ENGServiceLocator es=new ENGServiceLocator();
		int res=es.getENGServiceSoap().getActCategories(filter, ret_categories, start, count, username, errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"listActCategories ha dado error sin dar mas informaci—n":errorMessage.value);
		return ret_categories.value;	
	}
	
	public int saveActCategory(String login,int id,String name,int status, String description) throws ServiceException,RemoteException
	{
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		ENGServiceLocator es=new ENGServiceLocator();
		int res=0;
		if (id>0) {
			res=es.getENGServiceSoap().updateActCategory(login, id+"", name, description,status, errorMessage);
		}
		else
		{
			res=es.getENGServiceSoap().addActCategory(login, name, description, errorMessage);
		}
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"saveActCategory ha dado error sin dar mas informaci—n":errorMessage.value);
		return res;			
	}
	
	public int deleteActCategory(String login,int id,String name, String description) throws ServiceException,RemoteException
	{
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		ENGServiceLocator es=new ENGServiceLocator();
		int res=0;
		if (id>0) {
			res=es.getENGServiceSoap().deleteActCategory(login, ""+id, errorMessage);
		}
		return res;			
	}
	
	/********** COMPANY SERVICES CATEGORIES **********************/
	
	public int countCompCategories(String username) throws ServiceException,RemoteException {
		return countCompCategories("COUNT",username);
	}
	
	public int countCompCategories(String filter,String username) throws ServiceException,RemoteException {
		ArrayOfCategoryHolder ret_categories=new ArrayOfCategoryHolder();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		String strFilter=filter;
		ENGServiceLocator es=new ENGServiceLocator();
		if (!filter.toLowerCase().contains("count"))
			strFilter=" COUNT "+filter;
		int res=es.getENGServiceSoap().getCompCategories(strFilter, ret_categories, 0, 0, username,errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"countCompCategories ha dado error sin dar mas informaci—n.Filter:"+strFilter:errorMessage.value);
		return res;		
	}
	
	public Category[] listCompCategories(String filter,int start,int count,String username) throws ServiceException,RemoteException {
		ArrayOfCategoryHolder ret_categories=new ArrayOfCategoryHolder();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		IntHolder ih=new IntHolder();
		ih.value=count;
		ENGServiceLocator es=new ENGServiceLocator();
		int res=es.getENGServiceSoap().getCompCategories(filter, ret_categories, start, count, username, errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"listCompCategories ha dado error sin dar mas informaci—n":errorMessage.value);
		return ret_categories.value;	
	}
	
	public int saveCompCategory(String login,int id,String name,int status, String description) throws ServiceException,RemoteException
	{
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		ENGServiceLocator es=new ENGServiceLocator();
		int res=0;
		if (id>0) {
			res=es.getENGServiceSoap().updateCompCategory(login, id+"", name, description,status, errorMessage);
		}
		else
		{
			res=es.getENGServiceSoap().addCompCategory(login, name, description, errorMessage);
		}
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"saveActCategory ha dado error sin dar mas informaci—n":errorMessage.value);
		return res;			
	}
	
	public int deleteCompCategory(String login,int id,String name, String description) throws ServiceException,RemoteException
	{
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		ENGServiceLocator es=new ENGServiceLocator();
		int res=0;
		if (id>0) {
			res=es.getENGServiceSoap().deleteCompCategory(login, ""+id, errorMessage);
		}
		return res;			
	}
		
	/********** REQUESTS **********************/
	public int countRequests(String username) throws ServiceException,RemoteException {
		return countRequests("COUNT",username);
	}
	
	public int countRequests(String filter,String username) throws ServiceException,RemoteException {
		ArrayOfRequestHolder ret_categories=new ArrayOfRequestHolder();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		String strFilter=filter;
		ENGServiceLocator es=new ENGServiceLocator();
		if (!filter.toLowerCase().contains("count"))
			strFilter="COUNT "+filter;
		int res=es.getENGServiceSoap().getRequests(strFilter, ret_categories, 0, 0, username,errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"countRequests ha dado error sin dar mas informaci—n.Filter:"+strFilter:errorMessage.value);
		return res;		
	}
	
	public Request[] listRequests(String filter,int start,int count,String username) throws ServiceException,RemoteException {
		ArrayOfRequestHolder ret_requests=new ArrayOfRequestHolder();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		IntHolder ih=new IntHolder();
		ih.value=count;
		ENGServiceLocator es=new ENGServiceLocator();
		int res=es.getENGServiceSoap().getRequests(filter, ret_requests, start, count,username, errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"listRequests ha dado error sin dar mas informaci—n":errorMessage.value);
		return ret_requests.value;	
	}
	
	public int saveRequest(String login,int idRequest,String type, String category_id, String short_description,String description,String when,String where, String dateTime,String candidates,FilteringPrefs filtering,Status status)throws ServiceException,RemoteException
	{
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		ENGServiceLocator es=new ENGServiceLocator();
		int res=0;
		if (idRequest>0) {
			res=es.getENGServiceSoap().updateRequest(login, ""+idRequest, type, category_id, short_description, description, when, where, filtering, dateTime, candidates, status, 0, errorMessage);
					//updateRequest(login, ""+idRequest, type, category_id, description, when, where, filtering, dateTime , candidates,status, errorMessage);
		}
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"saveRequest ha dado error sin dar mas informaci—n":errorMessage.value);
		return res;			
	}
	
	public int deleteRequest(String login,int id,String name, String description) throws ServiceException,RemoteException
	{
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		ENGServiceLocator es=new ENGServiceLocator();
		int res=0;
		if (id>0) {
			res=es.getENGServiceSoap().deleteRequest(login, ""+id, errorMessage);
		}
		return res;			
	}
	
	/********** SKILLS **********************/
	public int countSkills(String username) throws ServiceException,RemoteException {
		return countSkills("COUNT",username);
	}
	
	public int countSkills(String filter,String username) throws ServiceException,RemoteException {
		ArrayOfSkillHolder ret_categories=new ArrayOfSkillHolder();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		String strFilter=filter;
		ENGServiceLocator es=new ENGServiceLocator();
		if (!filter.toLowerCase().contains("count"))
			strFilter="COUNT "+filter;
		int res=es.getENGServiceSoap().getSkills(strFilter, ret_categories, 0, 0, username,errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"countSkills ha dado error sin dar mas informaci—n.Filter:"+strFilter:errorMessage.value);
		return res;		
	}
	
	public Skill[] listSkills(String filter,int start,int count,String username) throws ServiceException,RemoteException {
		ArrayOfSkillHolder ret_skills=new ArrayOfSkillHolder();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		IntHolder ih=new IntHolder();
		ih.value=count;
		ENGServiceLocator es=new ENGServiceLocator();
		int res=es.getENGServiceSoap().getSkills(filter, ret_skills, start, count,username, errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"listSkills ha dado error sin dar mas informaci—n":errorMessage.value);
		return ret_skills.value;	
	}	
	
	public int saveSkill(String login,int skill_id,String skill)throws ServiceException,RemoteException
	{
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		ENGServiceLocator es=new ENGServiceLocator();
		int res=0;
		if (skill_id>0) {
			res=es.getENGServiceSoap().updateSkill(login, ""+skill_id, skill, errorMessage);
		}
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"saveSkill ha dado error sin dar mas informaci—n":errorMessage.value);
		return res;			
	}
	
	public int deleteSkill(String login,int skill_id) throws ServiceException,RemoteException
	{
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		ENGServiceLocator es=new ENGServiceLocator();
		int res=0;
		if (skill_id>0) {
			res=es.getENGServiceSoap().deleteSkill(login, ""+skill_id, errorMessage);
		}
		return res;			
	}
	
	/********** SERVICES **********************/
	public int countServices(String username) throws ServiceException,RemoteException {
		return countServices("COUNT",username);
	}
	
	public int countServices(String filter,String username) throws ServiceException,RemoteException {
		ArrayOfServiceHolder ret_categories=new ArrayOfServiceHolder();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		String strFilter=filter;
		ENGServiceLocator es=new ENGServiceLocator();
		if (!filter.toLowerCase().contains("count"))
			strFilter="COUNT "+filter;
		int res=es.getENGServiceSoap().getServices(strFilter, ret_categories, 0, 0,username, errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"countServices ha dado error sin dar mas informaci—n.Filter:"+strFilter:errorMessage.value);
		return res;		
	}
	
	public Service[] listServices(String filter,int start,int count,String username) throws ServiceException,RemoteException {
		ArrayOfServiceHolder ret_categories=new ArrayOfServiceHolder();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		IntHolder ih=new IntHolder();
		ih.value=count;
		ENGServiceLocator es=new ENGServiceLocator();
		int res=es.getENGServiceSoap().getServices(filter, ret_categories, start, count,username, errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"listServices ha dado error sin dar mas informaci—n":errorMessage.value);
		return ret_categories.value;	
	}
	
	public int saveService(String login,int service_id, String category, String short_desc, String detailed_info, String when_Service, String where_Service, Calendar deadline)throws ServiceException,RemoteException
	{
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		ENGServiceLocator es=new ENGServiceLocator();
		int res=0;
		if (service_id>0) {
			res=es.getENGServiceSoap().updateService(login,""+service_id, category, short_desc, detailed_info, when_Service, where_Service, deadline,0, errorMessage);
		}
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"saveService ha dado error sin dar mas informaci—n":errorMessage.value);
		return res;			
	}
	
	public int deleteService(String login,int service_id) throws ServiceException,RemoteException
	{
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		ENGServiceLocator es=new ENGServiceLocator();
		int res=0;
		if (service_id>0) {
			res=es.getENGServiceSoap().deleteService(login, ""+service_id, errorMessage);
		}
		return res;			
	}
	
	/********** OFFERS **********************/
	public int countOffers(String username) throws ServiceException,RemoteException {
		return countOffers("COUNT",username);
	}
	
	public int countOffers(String filter,String username) throws ServiceException,RemoteException {
		ArrayOfOfferHolder ret_categories=new ArrayOfOfferHolder();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		String strFilter=filter;
		ENGServiceLocator es=new ENGServiceLocator();
		if (!filter.toLowerCase().contains("count"))
			strFilter="COUNT "+filter;
		int res=es.getENGServiceSoap().getOffer(strFilter, ret_categories, 0, 0,username, errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"countOffers ha dado error sin dar mas informaci—n.Filter:"+strFilter:errorMessage.value);
		return res;		
	}
	
	public Offer[] listOffers(String filter,int start,int count,String username) throws ServiceException,RemoteException {
		ArrayOfOfferHolder ret_categories=new ArrayOfOfferHolder();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		IntHolder ih=new IntHolder();
		ih.value=count;
		ENGServiceLocator es=new ENGServiceLocator();
		int res=es.getENGServiceSoap().getOffer(filter, ret_categories, start, count,username, errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"listOffers ha dado error sin dar mas informaci—n":errorMessage.value);
		return ret_categories.value;	
	}	
	
	public int saveOffer(String login,int offer_id, String category, String short_desc, String detailed_info, String when_Offer, String where_Offer, Calendar deadline)throws ServiceException,RemoteException
	{
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		ENGServiceLocator es=new ENGServiceLocator();
		int res=0;
		if (offer_id>0) {
			res=es.getENGServiceSoap().updateOffer(login, offer_id, category, short_desc, detailed_info, when_Offer, where_Offer, deadline, 0,errorMessage);
		}
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"saveService ha dado error sin dar mas informaci—n":errorMessage.value);
		return res;			
	}
	
	public int deleteOffer(String login,int offer_id) throws ServiceException,RemoteException
	{
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		ENGServiceLocator es=new ENGServiceLocator();
		int res=0;
		if (offer_id>0) {
			res=es.getENGServiceSoap().deleteOffer(login, ""+offer_id, errorMessage);
		}
		return res;			
	}
	
	
	
	/********** REGIONS  **********************/
	public int countRegions(String username) throws ServiceException,RemoteException {
		return countRegions(username,"count");
	}
	
	public int countRegions(String username,String filter) throws ServiceException,RemoteException {
		ArrayOfRegionsHolder ret_regions=new ArrayOfRegionsHolder();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		String strFilter=filter;
		ENGServiceLocator es=new ENGServiceLocator();
		if (!filter.toLowerCase().contains("count"))
			strFilter="COUNT "+filter;
		int res=es.getENGServiceSoap().getRegions(filter, ret_regions, 0, 0,"", errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"countRegions ha dado error sin dar mas informaci—n.Filter:"+strFilter:errorMessage.value);
		return res;			
	}	
	
	
	public Regions[] listRegions(String filter,int start,int count,String username) throws ServiceException,RemoteException {
		ArrayOfRegionsHolder ret_regions=new ArrayOfRegionsHolder();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		IntHolder ih=new IntHolder();
		ih.value=count;
		ENGServiceLocator es=new ENGServiceLocator();
		int res=0;
		res=es.getENGServiceSoap().getRegions(filter, ret_regions, start, count,"", errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"listRegions ha dado error sin dar mas informaci—n":errorMessage.value);
		return ret_regions.value;	
	}	
	
	public int saveRegion(String login,String name,int region_id,String region_lat, String region_lon, String supraRegion, String country, String country_code, String lng,int radius)throws ServiceException,RemoteException
	{
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		ENGServiceLocator es=new ENGServiceLocator();
		int res=0;
		//Si es un update
		if (region_id>0) {
			//res=es.getENGServiceSoap().updateRegion(login, ""+region_id, name, country, country_code, region_lat, region_lon, ""+radius, lng, errorMessage);
			res=es.getENGServiceSoap().updateRegion(login, ""+region_id, name, supraRegion, country, country_code, region_lat, region_lon, ""+radius, lng, errorMessage);
		}
		else
		{
			res=es.getENGServiceSoap().addRegion(login, name,supraRegion, country,country_code, region_lat, region_lon, ""+radius, lng, errorMessage);
		}
	
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"saveRegion ha dado error sin dar mas informaci—n":errorMessage.value);
		return res;			
	}
	
	public int deleteRegion(String login,int region_id) throws ServiceException,RemoteException
	{
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		ENGServiceLocator es=new ENGServiceLocator();
		int res=0;
		if (region_id>0) {
			res=es.getENGServiceSoap().deleteRegion(login, ""+region_id, errorMessage);
		}
		return res;			
	} 
	
	
	/********** STATS **********************/
	public int countStats() throws ServiceException,RemoteException {
		return countStats("COUNT");
	}
	
	public int countStats(String filter) throws ServiceException,RemoteException {
		ArrayOfStatsHolder ret_categories=new ArrayOfStatsHolder();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		String strFilter=filter;
		ENGServiceLocator es=new ENGServiceLocator();
		if (!filter.toLowerCase().contains("count"))
			strFilter="COUNT "+filter;
		int res=es.getENGServiceSoap().getStats(strFilter, ret_categories, 0, 0, errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"countStats ha dado error sin dar mas informaci—n.Filter:"+strFilter:errorMessage.value);
		return res;		
	}
	
	public Stats[] listStats(String filter,int start,int count,String username) throws ServiceException,RemoteException {
		ArrayOfStatsHolder ret_categories=new ArrayOfStatsHolder();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		ENGServiceLocator es=new ENGServiceLocator();
		int res=es.getENGServiceSoap().getStats(filter, ret_categories, start, count,errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"listStats ha dado error sin dar mas informaci—n":errorMessage.value);
		return ret_categories.value;	
	}		
	
	public ObjStats[] listStatsSQL(String sql) throws ServiceException,RemoteException {
		ArrayOfObjStatsHolder ret_Stats=new ArrayOfObjStatsHolder();
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		ENGServiceLocator es=new ENGServiceLocator();
		int res=es.getENGServiceSoap().getStatsSql(sql, ret_Stats, errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"listStats ha dado error sin dar mas informaci—n":errorMessage.value);
		return ret_Stats.value;	
	}		
	
	public void addStats(String username,int event_id,Calendar when, int duration,String lat,String lon,String query) throws ServiceException,RemoteException {
		javax.xml.rpc.holders.StringHolder errorMessage= new javax.xml.rpc.holders.StringHolder();
		ENGServiceLocator es=new ENGServiceLocator();
		int res=es.getENGServiceSoap().addStat(username,""+event_id, when, duration, lat, lon, "SERVER", query, errorMessage);
				//.addStat(username,""+event_id, when, duration, lat, lon, query, errorMessage);
		if (res<0)
			throw new RemoteException(errorMessage.value==null?"addStats ha dado error sin dar mas informaci—n":errorMessage.value);
	}		
	
	
}
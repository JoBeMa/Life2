/* Life 2.0 Backoffice code Copyright (C) 2014 - Fundació i2CAT This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA. */

package net.i2cat.csade.life2.backoffice.servlet;

import java.io.IOException;
import java.rmi.RemoteException;

import javax.servlet.ServletException; 
import javax.servlet.http.HttpServlet; 
import javax.servlet.http.HttpServletRequest; 
import javax.servlet.http.HttpServletResponse; 
import javax.xml.rpc.ServiceException;

import net.i2cat.csade.life2.backoffice.bl.PlatformUserManager;
import net.i2cat.csade.life2.backoffice.bl.StatisticsManager;
import net.i2cat.csade.life2.backoffice.model.JQueryDataTableParamModel;
import net.i2cat.csade.life2.backoffice.util.DataTablesParamUtility;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.FilteringPrefs;
import net.i2cat.csade.life2.backoffice.clientws.b.engservice.Status;
import net.sf.json.JSONObject;



@SuppressWarnings("serial")
public class StatisticsService extends HttpServlet { 
     
    String message; 
     
    
    @Override 
    protected void doGet(HttpServletRequest request, HttpServletResponse response) 
            throws ServletException, IOException { 
        doPost(request, response); 
    }     
    
    /**
     * Funci—n que se ejecuta cuando el servlet recibe los datos
     */
    protected void doPost(HttpServletRequest request, HttpServletResponse response) 
            throws ServletException, IOException { 
    	String st=request.getParameter("estadistica"); 
    	String type=request.getParameter("respType"); 
    	String lng="";
    	if (request.getUserPrincipal()==null) response.sendRedirect("../index.html");
    	StatisticsManager sm=new StatisticsManager();
    	PlatformUserManager um=new PlatformUserManager();
    	String data="";
    	response.setContentType("text/plain");
    	if  (st.equals("hour"))
    	{
    		data=sm.getDatosConexiones(); //Done
    		if (type!=null)
    			response.setContentType("text/csv"); //"application/vnd.ms-excel"

    	}
       	else if (st.equals("day"))
       	{
           	int days=Integer.parseInt(request.getParameter("days"));
           	int role=Integer.parseInt(request.getParameter("role"));
           	lng=request.getParameter("lng");
    		data=sm.getDatosConexionesDia(days,role,lng); //Done
    		if (type!=null)
    			response.setContentType("text/csv"); //"application/vnd.ms-excel"
    		
       	}
    	else if (st.equals("device"))
    	{
    		data=sm.getDatosDispositivos();  //Done
    		if (type!=null)
    			response.setContentType("text/csv"); //"application/vnd.ms-excel"

    	}
    	else if (st.equals("role"))
    	{
    		data=sm.getDatosProfiles();      //Done
    		if (type!=null)
    			response.setContentType("text/csv"); //"application/vnd.ms-excel"

    	}    		
    	else if (st.equals("new_day"))
    	{
    		int days=Integer.parseInt(request.getParameter("days"));  //Done
    		int role=Integer.parseInt(request.getParameter("role"));
    		lng=request.getParameter("lng");
    		data=sm.getDatosNewUsersByDay(days,role,lng) ; 
    		if (type!=null)
    			response.setContentType("text/csv"); //"application/vnd.ms-excel"

    	}
    	else if (st.equals("get_data"))
    	{
    		data=sm.getPlatformData(type); 
    		if (type!=null)
    			response.setContentType("text/csv"); //"application/vnd.ms-excel"
    		else
    			response.setContentType("application/json");
    	}
       	else if (st.equals("events_post"))   //Done
       	{
       		int days=Integer.parseInt(request.getParameter("days"));
    		data=sm.getDatosEventsPost(days);
    		if (type!=null)
    			response.setContentType("text/csv"); //"application/vnd.ms-excel"
    		
       	}
       	else if (st.equals("list_bycategories"))
       	{
        	JQueryDataTableParamModel param = DataTablesParamUtility.getParam(request);
        	boolean showAll=false;
        	if ("true".equals(request.getParameter("showAll"))) 
        			showAll=true;
        	try 
    		{
        		JSONObject jsonResponse = sm.getListByCategoriesJSON(param, showAll);
        		data=jsonResponse.toString();
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not retrieve platform elements by category listing. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not retrieve platform elements by category listing.  Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");       		
       	}
       	else if (st.equals("actbycategories"))
       	{
        	JQueryDataTableParamModel param = DataTablesParamUtility.getParam(request);
        	boolean showAll=false;
        	if ("true".equals(request.getParameter("showAll"))) 
        			showAll=true;
        	try 
    		{
        		JSONObject jsonResponse = sm.getListActivitiesByCategoriesJSON(param, showAll);
        		data=jsonResponse.toString();
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not retrieve activities by category listing. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not retrieve activities by category listing.  Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");       		
       	}   
       	else if (st.equals("servbycategories"))
       	{
        	JQueryDataTableParamModel param = DataTablesParamUtility.getParam(request);
        	boolean showAll=false;
        	if ("true".equals(request.getParameter("showAll"))) 
        			showAll=true;
        	try 
    		{
        		JSONObject jsonResponse = sm.getListServicesByCategoriesJSON(param, showAll);
        		data=jsonResponse.toString();
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not retrieve commercial services by category listing. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not retrieve  commercial services by category listing.  Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");       		
       	}     	
    	/**************** CATEGORIES ****************************/
       	else if (st.equals("list_categories"))
       	{
        	JQueryDataTableParamModel param = DataTablesParamUtility.getParam(request);
        	boolean showAll=false;
        	if ("true".equals(request.getParameter("showAll"))) 
        			showAll=true;
        	try 
    		{
        		JSONObject jsonResponse = sm.getListCategoriesJSON(param, showAll);
        		data=jsonResponse.toString();
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not retrieve platform category listing. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not retrieve platform category listing.  Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");
       	}       	
      	else if (st.equals("save_category"))
       	{
      		int id=0;
    		String idCategory=request.getParameter("idCategory");
    		try {
    			id=Integer.parseInt(idCategory);
    		}
    		catch(NumberFormatException nfe) {} 
    		try 
    		{
    			String login=request.getUserPrincipal().getName();
    			int status=0;
    			try {
    				status=Integer.parseInt( request.getParameter("cat_status"));
    			}
    			catch(NumberFormatException nfe ) {}
    			if (login==null ) throw new ServiceException("Session expired!!");
    			String cat_name="";
    			String cat_desc="";
    			if (request.getParameter("cat_name")!=null)
    				cat_name=request.getParameter("cat_name");
    			if (request.getParameter("cat_desc")!=null)
    				cat_desc=request.getParameter("cat_desc");
    			id=sm.saveCategory(request.getUserPrincipal().getName(), id, cat_name, status,cat_desc);
    			data="{ \"message\": \"Category with id "+id+ " saved.\" }";
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not save category. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not save category. Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");
       	} 
      	else if (st.equals("get_category"))
       	{
      		int id=0;
    		String idCategory=request.getParameter("idCategory");
    		try {
    			id=Integer.parseInt(idCategory);
    		}
    		catch(NumberFormatException nfe) {} 
    		try 
    		{
    			data=sm.getCategory(""+id).toString();
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not get category. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not get category. Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json; charset=utf-8");
       	}  
      	else if (st.equals("deleteCategory"))
       	{
      		int id=0;
    		String idCategory=request.getParameter("idCategory");
    		try 
    		{
    			try {
    				id=Integer.parseInt(idCategory);
    			}
    			catch(NumberFormatException nfe) 
    			{
    				throw new ServiceException(" Incorrect ID:\" }");
    			} 
    			String login=request.getUserPrincipal().getName();
    			if (login==null ) throw new ServiceException("Session expired!!");
    			if (sm.deleteCategory(login, id, "", "")>0)
    				data="{ \"message\": \"Category successfully deleted!\" }";
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not delete category. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not delete category. Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");
       	} 
    	
       	/**************** Activity CATEGORIES ****************************/
       	else if (st.equals("list_act_categories"))
       	{
        	JQueryDataTableParamModel param = DataTablesParamUtility.getParam(request);
        	boolean showAll=false;
        	if ("true".equals(request.getParameter("showAll"))) 
        			showAll=true;
        	try 
    		{
        		JSONObject jsonResponse = sm.getListActCategoriesJSON(param, showAll);
        		data=jsonResponse.toString();
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not retrieve platform category listing. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not retrieve platform category listing.  Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");
       	}       	
      	else if (st.equals("save_actcategory"))
       	{
      		int id=0;
    		String idCategory=request.getParameter("idActCategory");
    		try {
    			id=Integer.parseInt(idCategory);
    		}
    		catch(NumberFormatException nfe) {} 
    		try 
    		{
    			String login=request.getUserPrincipal().getName();
    			int status=0;
    			try {
    				status=Integer.parseInt( request.getParameter("act_cat_status"));
    			}
    			catch(NumberFormatException nfe ) {}
    			if (login==null ) throw new ServiceException("Session expired!!");
    			String cat_name="";
    			String cat_desc="";
    			if (request.getParameter("act_cat_name")!=null)
    				cat_name=request.getParameter("act_cat_name");
    			if (request.getParameter("act_cat_desc")!=null)
    				cat_desc=request.getParameter("act_cat_desc");
    			id=sm.saveActCategory(request.getUserPrincipal().getName(), id, cat_name, status,cat_desc);
    			data="{ \"message\": \"Activity category with id "+id+ " saved.\" }";
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not save activity category. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not save activity category. Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");
       	} 
      	else if (st.equals("get_actcategory"))
       	{
      		int id=0;
    		String idCategory=request.getParameter("idActCategory");
    		try {
    			id=Integer.parseInt(idCategory);
    		}
    		catch(NumberFormatException nfe) {} 
    		try 
    		{
    			data=sm.getActCategory(""+id).toString();
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not get activity category. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not get activity category. Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json; charset=utf-8");
       	}  
      	else if (st.equals("deleteActCategory"))
       	{
      		int id=0;
    		String idCategory=request.getParameter("idActCategory");
    		try 
    		{
    			try {
    				id=Integer.parseInt(idCategory);
    			}
    			catch(NumberFormatException nfe) 
    			{
    				throw new ServiceException(" Incorrect ID:\" }");
    			} 
    			String login=request.getUserPrincipal().getName();
    			if (login==null ) throw new ServiceException("Session expired!!");
    			if (sm.deleteActCategory(login, id, "", "")>0)
    				data="{ \"message\": \"Activity Category successfully deleted!\" }";
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not delete activity category. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not delete activity category. Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");
       	} 
 
       	/**************** Company Service CATEGORIES ****************************/
       	else if (st.equals("list_comp_categories"))
       	{
        	JQueryDataTableParamModel param = DataTablesParamUtility.getParam(request);
        	boolean showAll=false;
        	if ("true".equals(request.getParameter("showAll"))) 
        			showAll=true;
        	try 
    		{
        		JSONObject jsonResponse = sm.getListCompCategoriesJSON(param, showAll);
        		data=jsonResponse.toString();
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not retrieve company services category listing. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not retrieve company services category listing.  Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");
       	}       	
      	else if (st.equals("save_compcategory"))
       	{
      		int id=0;
    		String idCategory=request.getParameter("idCompCategory");
    		try {
    			id=Integer.parseInt(idCategory);
    		}
    		catch(NumberFormatException nfe) {} 
    		try 
    		{
    			String login=request.getUserPrincipal().getName();
    			int status=0;
    			try {
    				status=Integer.parseInt( request.getParameter("comp_cat_status"));
    			}
    			catch(NumberFormatException nfe ) {}
    			if (login==null ) throw new ServiceException("Session expired!!");
    			String cat_name="";
    			String cat_desc="";
    			if (request.getParameter("comp_cat_name")!=null)
    				cat_name=request.getParameter("comp_cat_name");
    			if (request.getParameter("comp_cat_desc")!=null)
    				cat_desc=request.getParameter("comp_cat_desc");
    			id=sm.saveCompCategory(request.getUserPrincipal().getName(), id, cat_name, status,cat_desc);
    			data="{ \"message\": \"Company service category with id "+id+ " saved.\" }";
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not save Company service category. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not save Company service category. Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");
       	} 
      	else if (st.equals("get_compcategory"))
       	{
      		int id=0;
    		String idCategory=request.getParameter("idCompCategory");
    		try {
    			id=Integer.parseInt(idCategory);
    		}
    		catch(NumberFormatException nfe) {} 
    		try 
    		{
    			data=sm.getCompCategory(""+id).toString();
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not get Company service category. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not get Company service category. Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json; charset=utf-8");
       	}  
      	else if (st.equals("deleteCompCategory"))
       	{
      		int id=0;
    		String idCategory=request.getParameter("idCompCategory");
    		try 
    		{
    			try {
    				id=Integer.parseInt(idCategory);
    			}
    			catch(NumberFormatException nfe) 
    			{
    				throw new ServiceException(" Incorrect ID:\" }");
    			} 
    			String login=request.getUserPrincipal().getName();
    			if (login==null ) throw new ServiceException("Session expired!!");
    			if (sm.deleteCompCategory(login, id, "", "")>0)
    				data="{ \"message\": \"Company service category successfully deleted!\" }";
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not delete Company service category. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not delete Company service category. Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");
       	} 
    	    	
    	
    	/******************************* REQUESTS ******************************
       	else if (st.equals("list_requests"))
       	{
        	JQueryDataTableParamModel param = DataTablesParamUtility.getParam(request);
        	boolean showAll=false;
        	if ("true".equals(request.getParameter("showAll"))) 
        			showAll=true;
        	try 
    		{
        		JSONObject jsonResponse = sm.getListRequestsJSON(param,showAll);
        		data=jsonResponse.toString();
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not retrieve platform Request listing. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not retrieve platform Request listing.  Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");
       	}       	
      	else if (st.equals("save_request"))
       	{
      		int id=0;
    		String idRequest=request.getParameter("idRequest");
    		try {
    			id=Integer.parseInt(idRequest);
    		}
    		catch(NumberFormatException nfe) {} 
    		try 
    		{
    			String login=request.getUserPrincipal().getName();
    			if (login==null ) throw new ServiceException("Session expired!!");
    			int iStat=Integer.parseInt(request.getParameter("req_status"));
    			Status status=null;
    			FilteringPrefs fc=null;
    			switch (iStat)
    			{
    			case 1: status=Status.Submitted; break;
    			case 2: status=Status.Pending; break;
    			case 3: status=Status.Pending_Approval; break;
    			case 4: status=Status.Accepted; break;
    			case 5: status=Status.Closed; break;
    			case 8: status=Status.Rejected; break;
    			}
    			int idFiltering=Integer.parseInt(request.getParameter("req_filtering"));
    			switch(idFiltering)
    			{
    				case 1: fc=FilteringPrefs.male_female; break;
    				case 2: fc=FilteringPrefs.closest; break;
    				case 3: fc=FilteringPrefs.best; break;
    				case 4: fc=FilteringPrefs.recommended; break;
    				case 5: fc=FilteringPrefs.my_contacts; break;
    			}
    			String req_desc=(request.getParameter("req_desc")==null?"":request.getParameter("req_desc"));
    			String req_short_desc=(request.getParameter("req_short_desc")==null?"":request.getParameter("req_short_desc"));
    			String req_when=(request.getParameter("req_when")==null?"":request.getParameter("req_when"));
    			String req_where=(request.getParameter("req_where")==null?"":request.getParameter("req_where"));
    			
    			id=sm.saveRequest(request.getUserPrincipal().getName(), id, request.getParameter("req_type"), request.getParameter("req_cat"),req_short_desc,  req_desc, req_when, req_where, request.getParameter("req_deadline"), request.getParameter("req_candidates"),status,fc);
    			
    			data="{ \"message\": \"Request with id "+id+ " saved.\" }";
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not save Request. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not save Request. Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");
       	} 
      	else if (st.equals("get_request"))
       	{
      		int id=0;
    		String idRequest=request.getParameter("idRequest");
    		try {
    			id=Integer.parseInt(idRequest);
    		}
    		catch(NumberFormatException nfe) {} 
    		try 
    		{
    			data=sm.getRequest(""+id).toString();
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not get Request. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not get Request. Reason:"+se.getMessage() +".\" }";
    		}	
    		response.setContentType("application/json; charset=utf-8");
       	}  
      	else if (st.equals("deleteRequest"))
       	{
      		int id=0;
    		String idCategory=request.getParameter("idRequest");
    		try 
    		{
    			try {
    				id=Integer.parseInt(idCategory);
    			}
    			catch(NumberFormatException nfe) 
    			{
    				throw new ServiceException(" Incorrect ID:\" }");
    			} 
    			String login=request.getUserPrincipal().getName();
    			if (login==null ) throw new ServiceException("Session expired!!");
    			if (sm.deleteRequest(login, id, "", "")>0)
    				data="{ \"message\": \"Request successfully deleted!\" }";
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not delete Request. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not delete Request. Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");
      	} */
    	/******************************* ACTIVITIES ******************************/
       	else if (st.equals("list_activities"))
       	{
        	JQueryDataTableParamModel param = DataTablesParamUtility.getParam(request);
        	boolean showAll=false;
        	if ("true".equals(request.getParameter("showAll"))) 
        			showAll=true;
        	try 
    		{
            	if (!showAll && request.getParameter("lng")!=null && !"".equals(request.getParameter("lng")))
            	{
            		lng=request.getParameter("lng");      		
            		param.login=um.getLoginInLanguage(lng);
            	}
            	String state=request.getParameter("state");
        		JSONObject jsonResponse = sm.getListActivitiesJSON(param,showAll,state);
        		data=jsonResponse.toString();
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not retrieve platform Activity listing. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not retrieve platform Activity listing.  Reason:"+se.getMessage() +".\" }";
    		}	
        	response.setContentType("application/json"); 
       	}  
      	else if (st.equals("get_activity"))
       	{
      		int id=0;
    		String idActivity=request.getParameter("idActivity");
    		try {
    			id=Integer.parseInt(idActivity);
    		}
    		catch(NumberFormatException nfe) {} 
    		try 
    		{
    			data=sm.getActivity(""+id).toString();
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not get activity. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not get activity. Reason:"+se.getMessage() +".\" }";
    		}	
    		response.setContentType("application/json; charset=utf-8");
       	} 
      	else if (st.equals("save_activity"))
       	{
      		int id=0;
    		String idRequest=request.getParameter("idActivity");
    		try {
    			id=Integer.parseInt(idRequest);
    		}
    		catch(NumberFormatException nfe) {} 
    		try 
    		{
    			String login=request.getUserPrincipal().getName();
    			if (login==null ) throw new ServiceException("Session expired!!");
    			
    			id=sm.saveActivity(request.getUserPrincipal().getName(), id, request.getParameter("act_category"), request.getParameter("act_short_desc"), request.getParameter("act_detailed_info"), request.getParameter("act_when"), request.getParameter("act_where"), request.getParameter("act_deadline"));
    			
    			data="{ \"message\": \"Activity with id "+id+ " saved.\" }";
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not save Activity. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not save Activity. Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");
       	} 
      	else if (st.equals("deleteActivity"))
       	{
      		int id=0;
    		String idActivity=request.getParameter("idActivity");
    		try 
    		{
    			try {
    				id=Integer.parseInt(idActivity);
    			}
    			catch(NumberFormatException nfe) 
    			{
    				throw new ServiceException(" Incorrect ID:\" }");
    			} 
    			String login=request.getUserPrincipal().getName();
    			if (login==null ) throw new ServiceException("Session expired!!");
    			if (sm.deleteActivity(login, id)>0)
    				data="{ \"message\": \"Activity successfully deleted!\" }";
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not delete Activity. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not delete Activity. Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");
      	}    	
    	/******************************* SKILLS ******************************/
       	else if (st.equals("list_skills"))
       	{
        	JQueryDataTableParamModel param = DataTablesParamUtility.getParam(request);
        	boolean showAll=false;
        	if ("true".equals(request.getParameter("showAll"))) 
        			showAll=true;
        	try 
    		{
            	if (!showAll && request.getParameter("lng")!=null && !"".equals(request.getParameter("lng")))
            	{
            		lng=request.getParameter("lng");      		
            		param.login=um.getLoginInLanguage(lng);
            	}
        		JSONObject jsonResponse = sm.getListSkillsJSON(param,showAll);
        		data=jsonResponse.toString();
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not retrieve platform Skill listing. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not retrieve platform Skill listing.  Reason:"+se.getMessage() +".\" }";
    		}	
        	response.setContentType("application/json"); 
       	}   
       	else if (st.equals("get_skill"))
       	{
      		int id=0;
    		String idSkill=request.getParameter("idSkill");
    		try {
    			id=Integer.parseInt(idSkill);
    		}
    		catch(NumberFormatException nfe) {} 
    		try 
    		{
    			data=sm.getSkill(id+"").toString();
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not get skill. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not get skill. Reason:"+se.getMessage() +".\" }";
    		}	
    		response.setContentType("application/json; charset=utf-8");
       	} 
      	else if (st.equals("save_skill"))
       	{
      		int id=0;
    		String idSkill=request.getParameter("idSkill");
    		try {
    			id=Integer.parseInt(idSkill);
    		}
    		catch(NumberFormatException nfe) {} 
    		try 
    		{
    			String login=request.getUserPrincipal().getName();
    			if (login==null ) throw new ServiceException("Session expired!!");
    			
    			id=sm.saveSkill(request.getUserPrincipal().getName(), id, request.getParameter("sk_skill"));
    			
    			data="{ \"message\": \"Skill with id "+id+ " saved.\" }";
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not save Skill. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not save Skill. Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");
       	} 
      	else if (st.equals("deleteSkill"))
       	{
      		int id=0;
    		String idSkill=request.getParameter("idSkill");
    		try 
    		{
    			try {
    				id=Integer.parseInt(idSkill);
    			}
    			catch(NumberFormatException nfe) 
    			{
    				throw new ServiceException(" Incorrect ID:\" }");
    			} 
    			String login=request.getUserPrincipal().getName();
    			if (login==null ) throw new ServiceException("Session expired!!");
    			if (sm.deleteSkill(login, id)>0)
    				data="{ \"message\": \"Skill successfully deleted!\" }";
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not delete Skill. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not delete Skill. Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");
      	}      	
       	/******************************* OFFERS ******************************/
       	else if (st.equals("list_offers"))
       	{
        	JQueryDataTableParamModel param = DataTablesParamUtility.getParam(request);
        	boolean showAll=false;
        	if ("true".equals(request.getParameter("showAll"))) 
        			showAll=true;
        	try 
    		{
            	if (!showAll && request.getParameter("lng")!=null && !"".equals(request.getParameter("lng")))
            	{
            		lng=request.getParameter("lng");      		
            		param.login=um.getLoginInLanguage(lng);
            	}
            	String state=request.getParameter("state");
        		JSONObject jsonResponse = sm.getListOffersJSON(param,showAll,state);
        		data=jsonResponse.toString();
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not retrieve platform Offer listing. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not retrieve platform Offer listing.  Reason:"+se.getMessage() +".\" }";
    		}	
        	response.setContentType("application/json"); 
       	}
       	else if (st.equals("get_offer"))
       	{
      		int id=0;
    		String idOffer=request.getParameter("idOffer");
    		try {
    			id=Integer.parseInt(idOffer);
    		}
    		catch(NumberFormatException nfe) {} 
    		try 
    		{
    			data=sm.getOffer(""+id).toString();
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not get offer. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not get offer. Reason:"+se.getMessage() +".\" }";
    		}	
    		response.setContentType("application/json; charset=utf-8");
       	} 
      	else if (st.equals("save_offer"))
       	{
      		int id=0;
    		String idOffer=request.getParameter("idOffer");
    		try {
    			id=Integer.parseInt(idOffer);
    		}
    		catch(NumberFormatException nfe) {} 
    		try 
    		{
    			String login=request.getUserPrincipal().getName();
    			if (login==null ) throw new ServiceException("Session expired!!");
    			
    			id=sm.saveOffer(request.getUserPrincipal().getName(), id, request.getParameter("off_category"), request.getParameter("off_short_desc"), request.getParameter("off_detailed_info"), request.getParameter("off_when"), request.getParameter("off_where"), request.getParameter("off_deadline"));
    			
    			data="{ \"message\": \"Offer with id "+id+ " saved.\" }";
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not save Offer. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not save Offer. Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");
       	} 
      	else if (st.equals("deleteOffer"))
       	{
      		int id=0;
    		String idOffer=request.getParameter("idOffer");
    		try 
    		{
    			try {
    				id=Integer.parseInt(idOffer);
    			}
    			catch(NumberFormatException nfe) 
    			{
    				throw new ServiceException(" Incorrect ID:\" }");
    			} 
    			String login=request.getUserPrincipal().getName();
    			if (login==null ) throw new ServiceException("Session expired!!");
    			if (sm.deleteOffer(login, id)>0)
    				data="{ \"message\": \"Offer successfully deleted!\" }";
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not delete Offer. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not delete Offer. Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");
      	}  
      	/******************************* SERVICES ******************************/
       	else if (st.equals("list_services"))
       	{
        	JQueryDataTableParamModel param = DataTablesParamUtility.getParam(request);
        	boolean showAll=false;
        	if ("true".equals(request.getParameter("showAll"))) 
        			showAll=true;
        	try 
    		{
            	if (!showAll && request.getParameter("lng")!=null && !"".equals(request.getParameter("lng")))
            	{
            		lng=request.getParameter("lng");      		
            		param.login=um.getLoginInLanguage(lng);
            	}
            	String state=request.getParameter("state");
        		JSONObject jsonResponse = sm.getListServicesJSON(param,showAll,state);
        		data=jsonResponse.toString();
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not retrieve platform services listing. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not retrieve platform services listing.  Reason:"+se.getMessage() +".\" }";
    		}	
        	response.setContentType("application/json"); 
       	}
       	else if (st.equals("get_service"))
       	{
      		int id=0;
    		String idService=request.getParameter("idService");
    		try {
    			id=Integer.parseInt(idService);
    		}
    		catch(NumberFormatException nfe) {} 
    		try 
    		{
    			data=sm.getService(""+id).toString();
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not get service. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not get service. Reason:"+se.getMessage() +".\" }";
    		}	
    		response.setContentType("application/json; charset=utf-8"); 
       	} 
      	else if (st.equals("save_service"))
       	{
      		int id=0;
    		String idService=request.getParameter("idService");
    		try {
    			id=Integer.parseInt(idService);
    		}
    		catch(NumberFormatException nfe) {} 
    		try 
    		{
    			String login=request.getUserPrincipal().getName();
    			if (login==null ) throw new ServiceException("Session expired!!");
    			
    			id=sm.saveService(request.getUserPrincipal().getName(), id, request.getParameter("ser_category"), request.getParameter("ser_short_desc"), request.getParameter("ser_detailed_info"), request.getParameter("ser_when"), request.getParameter("ser_where"), request.getParameter("ser_deadline"));
    			
    			data="{ \"message\": \"Service with id "+id+ " saved.\" }";
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not save Service. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not save Service. Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");
       	} 
      	else if (st.equals("deleteService"))
       	{
      		int id=0;
    		String idService=request.getParameter("idService");
    		try 
    		{
    			try {
    				id=Integer.parseInt(idService);
    			}
    			catch(NumberFormatException nfe) 
    			{
    				throw new ServiceException(" Incorrect ID:\" }");
    			} 
    			String login=request.getUserPrincipal().getName();
    			if (login==null ) throw new ServiceException("Session expired!!");
    			if (sm.deleteService(login, id)>0)
    				data="{ \"message\": \"Service successfully deleted!\" }";
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not delete Service. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not delete Service. Reason:"+se.getMessage() +".\" }";
    		}	
    		response.setContentType("application/json"); 
      	}     	
    	/******************************* REGIONS ******************************/
       	else if (st.equals("list_regions"))
       	{
        	JQueryDataTableParamModel param = DataTablesParamUtility.getParam(request);
        	boolean showAll=false;
        	if ("true".equals(request.getParameter("showAll"))) 
        			showAll=true;
        	try 
    		{
        		JSONObject jsonResponse = sm.getListRegionsJSON(param,showAll);
        		data=jsonResponse.toString();
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not retrieve platform Region listing. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not retrieve platform Region listing.  Reason:"+se.getMessage() +".\" }";
    		}	
        	response.setContentType("application/json"); 
       	}   
       	else if (st.equals("get_region"))
       	{
      		int id=0;
    		String idRegion=request.getParameter("idRegion");
    		try {
    			id=Integer.parseInt(idRegion);
    		}
    		catch(NumberFormatException nfe) {} 
    		try 
    		{
    			data=sm.getRegion(id+"").toString();
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not get region. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not get region. Reason:"+se.getMessage() +".\" }";
    		}	
    		response.setContentType("application/json; charset=utf-8");
       	} 
      	else if (st.equals("save_region"))
       	{
      		int id=0;
    		String idSkill=request.getParameter("idRegion");
    		try {
    			id=Integer.parseInt(idSkill);
    		}
    		catch(NumberFormatException nfe) {} 
    		try 
    		{
    			String login=request.getUserPrincipal().getName();
    			if (login==null ) throw new ServiceException("Session expired!!");
    			
    			id=sm.saveRegion(request.getUserPrincipal().getName(), id, request.getParameter("rg_name"), request.getParameter("rg_latitude"), request.getParameter("rg_longitude"), request.getParameter("rg_country"), request.getParameter("rg_country_code"),request.getParameter("rg_lng"), Integer.parseInt(request.getParameter("rg_radious")));
    			
    			data="{ \"message\": \"Region with id "+id+ " saved.\" }";
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not save Region. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not save Region. Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");
       	} 
      	else if (st.equals("deleteRegion"))
       	{
      		int id=0;
    		String idRegion=request.getParameter("idRegion");
    		try 
    		{
    			try {
    				id=Integer.parseInt(idRegion);
    			}
    			catch(NumberFormatException nfe) 
    			{
    				throw new ServiceException(" Incorrect ID:\" }");
    			} 
    			String login=request.getUserPrincipal().getName();
    			if (login==null ) throw new ServiceException("Session expired!!");
    			if (sm.deleteRegion(login, id)>0)
    				data="{ \"message\": \"Region successfully deleted!\" }";
    		}
    		catch (RemoteException re) {
    			data="{ \"message\": \"Could not delete Region. Reason:"+re.getMessage() +".\" }";
    		}
    		catch(ServiceException se) {
    			data="{ \"message\": \"Could not delete Region. Reason:"+se.getMessage() +".\" }";
    		}	
       		response.setContentType("application/json");
      	}      	
    	
    	
    	response.getWriter().print(data);
    	response.getWriter().close();
    }
  
	
	
}












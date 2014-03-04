/* Life 2.0 Backoffice code Copyright (C) 2014 - Fundació i2CAT This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA. */

package net.i2cat.csade.life2.backoffice.servlet;

import java.io.IOException;
import java.io.InputStream;
import java.rmi.RemoteException;
import java.util.List;

import javax.servlet.ServletException; 
import javax.servlet.http.HttpServlet; 
import javax.servlet.http.HttpServletRequest; 
import javax.servlet.http.HttpServletResponse; 
import javax.xml.rpc.ServiceException;
import org.apache.commons.fileupload.FileItem;
import org.apache.commons.fileupload.FileUploadException;
import org.apache.commons.fileupload.disk.DiskFileItemFactory;
import org.apache.commons.fileupload.servlet.ServletFileUpload;
import org.apache.commons.io.FilenameUtils;

import net.i2cat.csade.life2.backoffice.util.ChangablePropertiesManager;
import net.i2cat.csade.life2.backoffice.util.DataTablesParamUtility;
import net.i2cat.csade.life2.backoffice.util.ImageUtil;
import net.i2cat.csade.life2.backoffice.util.MailUtils;
import net.i2cat.csade.life2.backoffice.util.PasswordGenerator;
import net.i2cat.csade.life2.backoffice.model.JQueryDataTableParamModel;
import net.i2cat.csade.life2.backoffice.model.PlatformUser;
import net.i2cat.csade.life2.backoffice.model.User;
import net.i2cat.csade.life2.backoffice.bl.PlatformUserManager;
import net.sf.json.JSONObject;



@SuppressWarnings("serial")
public class UserManagementService extends HttpServlet { 
     
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
    	ChangablePropertiesManager cpm=new ChangablePropertiesManager(this.getServletContext());
    	String operation=request.getParameter("operation"); 
    	PlatformUserManager pum=new PlatformUserManager();
    	String data="";
    	if (operation!=null && !"".equals(operation))
    	{
	    	if (operation.equals("savePicturePreference"))
	    	{
	    		String photo_hor=request.getParameter("photo_hor"); 
	    		cpm.saveProperty("photo_hor", photo_hor);
	    		
	    		data="{ \"message\": \"preferences saved.\" }";
	    	}
	    	if (operation.equals("getPicturePreference"))
	    	{
	    		String photo_hor=cpm.getProperty("photo_hor"); 
	    
	    		data="{ \"photo_hor\": \""+photo_hor+"\"}";
	    	}	    	
	    		
	    	if (operation.equals("getPlatformUser"))
	    	{
	    		String login=request.getParameter("login"); 
	    		try 
	    		{
	    			data=pum.getUser(login).toJSON().toString();
	    		}
	    		catch (RemoteException re) {
	    			data="{ \"message\": \"Could not not retrieve user with login="+login+ " Reason:"+re.getMessage() +".\" }";
	    		}
	    		catch(ServiceException se) {
	    			data="{ \"message\": \"Could not not retrieve user with login="+login+ " Reason:"+se.getMessage() +".\" }";
	    		}
	    	}
	    	if (operation.equals("delPlatformUser"))
	    	{
	    		String login=request.getParameter("login");
	    		try 
	    		{
	    			if (!request.isUserInRole("admin"))
	    				throw new ServiceException("You are not allowed to delete users");
	    			if (login!=null && login.equals(request.getUserPrincipal().getName()))
	    				throw new ServiceException("You cannot delete your own user");
	    			pum.deleteUser(login);
	    			data="{ \"message\": \"User with login "+login+ " deleted.\" }";
	    		}
	    		catch (RemoteException re) {
	    			data="{ \"message\": \"Could not not delete user with login="+login+ " Reason:"+re.getMessage() +".\" }";
	    		}
	    		catch(ServiceException se) {
	    			data="{ \"message\": \"Could not not delete user with login="+login+ " Reason:"+se.getMessage() +".\" }";
	    		}
	    	}
	    	if (operation.equals("savePlatformUser"))
	    	{
	    		FileItem uploadedFile=null;
	    		PlatformUser user=null;
	    		int res=0;
	    		byte[] foto=null;
	    		try 
	    		{
	    			if (!request.isUserInRole("admin"))
	    				throw new ServiceException("You are not allowed to upadte users");
	    			user=new PlatformUser();
	    			user.setNew(false);
		    		ServletFileUpload sfu=new ServletFileUpload(new DiskFileItemFactory());
		    		sfu.setFileSizeMax(329000);
		    		sfu.setHeaderEncoding("UTF-8");
		    		@SuppressWarnings("unchecked")
					List<FileItem> items = sfu.parseRequest(request);
		    		
					for (FileItem item : items) {
						if (item.isFormField()) {
							if (item.getFieldName().equals("login"))
								user.setLogin(item.getString());
							if (item.getFieldName().equals("username")) user.setLogin(item.getString());
							if (item.getFieldName().equals("password")) {
								user.setPass(item.getString());
							}
							if (item.getFieldName().equals("idUser")) {
								if (item.getString()==null || "".equals(item.getString()) )
									user.setNew(true);
							}							
							if (item.getFieldName().equals("name")) 
							{
								byte[] fnb = item.get();
								String text=PasswordGenerator.utf8Decoder(fnb);
								user.setName(text);
							}
							if (item.getFieldName().equals("email")) 
							{
								String mail=item.getString();
								if (MailUtils.isValidEmail(mail))
									user.setEmail(mail);
								else
									throw new ServiceException("El email del usuario es incorrecto");
							}
							if (item.getFieldName().equals("telephonenumber")) user.setTelephonenumber(item.getString());
							if (item.getFieldName().equals("role")) user.setRole(Integer.parseInt(item.getString()));
							if (item.getFieldName().equals("language")) user.setLanguage(item.getString());
							if (item.getFieldName().equals("notification_level")) user.setNotification_level(item.getString());
							if (item.getFieldName().equals("promoter_id")) user.setPromoter_id(item.getString());
							if (item.getFieldName().equals("user_average_mark")) user.setUser_average_mark(item.getString());
							if (item.getFieldName().equals("user_votes")) user.setUser_votes(item.getString());
							if (item.getFieldName().equals("latitude")) user.setHome_area_lat(item.getString());
							if (item.getFieldName().equals("longitude")) user.setHome_area_lon(item.getString());
							if (item.getFieldName().equals("enabled")) user.setEnabled(item.getString().equals("0")?0:1 );
						}
						else
						{
							uploadedFile=item;
							String inputExtension = FilenameUtils.getExtension(uploadedFile.getName().toLowerCase());
							if ("jpg".equals(inputExtension)||"gif".equals(inputExtension)||"png".equals(inputExtension))
							{
								InputStream filecontent = item.getInputStream();
								foto=new byte[(int) uploadedFile.getSize()]; 
								filecontent.read(foto, 0, (int) uploadedFile.getSize());
								
							}
							//else
							//	throw new FileUploadException("Extension not supported. Only jpg,gif or png files are allowed");
						}
					}
					res=pum.saveUser(user);
					if (foto!=null)
					{
						//String v=cpm.getProperty("photo_hor");
						//byte[] resizedPhoto=ImageUtil.resizeImageAsJPG(foto, (v==null || "".equals(v)) ?200:Integer.parseInt(v));
						pum.uploadFoto(user.getLogin(), foto);
					}
		    		data="{ \"message\": \"User with login "+user.getLogin()+ " (id="+res+") saved.\" }";
	    		}
	    		catch(RemoteException exc) {
	    			data="{ \"message\": \"Could not not save user with login="+user.getLogin()+ " Reason:"+exc.getMessage() +".\" }";
	    		}
	    		catch(ServiceException exc) {
	    			data="{ \"message\": \"Could not not save user with login="+user.getLogin()+ " Reason:"+exc.getMessage() +".\" }";
	    		}
	    		catch(FileUploadException exc)
	    		{
	    			data="{ \"message\": \"User with login "+user.getLogin()+ " (id="+res+") saved, but there was a problem uploading picture:"+exc.getMessage()+"\" }";
	    		}
	    	}
	    	if (operation.equals("listPlatformUsers"))
	    	{
	        	JQueryDataTableParamModel param = DataTablesParamUtility.getParam(request);
	        	try 
	    		{
	        		JSONObject jsonResponse = pum.getPlatformUsersJSON(param);
	        		data=jsonResponse.toString();
	        		
	    		}
	    		catch (RemoteException re) {
	    			data="{ \"message\": \"Could not not retrieve platform user listing. Reason:"+re.getMessage() +".\" }";
	    		}
	    		catch(ServiceException se) {
	    			data="{ \"message\": \"Could not not retrieve platform user listing.  Reason:"+se.getMessage() +".\" }";
	    		}	    		
	    	}		    	
    	}
    	response.setContentType("application/json;charset=UTF-8"); 
    	//response.setContentType("application/json");
    	response.getWriter().print(data);
    	response.getWriter().close();
    }
  
	
	
}












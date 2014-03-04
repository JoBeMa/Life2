/* Life 2.0 Backoffice code Copyright (C) 2014 - Fundació i2CAT This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA. */

package net.i2cat.csade.life2.backoffice.login;

import java.io.IOException;
import java.util.Map;
import net.i2cat.csade.life2.backoffice.bl.PlatformUserManager;
import net.i2cat.csade.life2.backoffice.model.PlatformUser;
import net.i2cat.csade.life2.backoffice.model.User;

import javax.security.auth.callback.Callback;
import javax.security.auth.callback.NameCallback;
import javax.security.auth.callback.PasswordCallback;
import javax.security.auth.callback.UnsupportedCallbackException;
import javax.security.auth.Subject;
import javax.security.auth.callback.CallbackHandler;
import javax.security.auth.login.LoginException;
import javax.security.auth.spi.LoginModule;
import javax.xml.rpc.ServiceException;

public class Life2Login implements LoginModule {
	
    /** Callback handler to store between initialization and authentication. */
    private CallbackHandler handler;
 
    /** Subject to store. */
    private Subject subject;
 
    /** Login name. */
    private String login;
    
    /** Userid **/
    private int userid;
    
    /** RoleID **/
    private int roleid;
    
    private PlatformUser theUser;
    
	public boolean abort() throws LoginException {
		return false;
	}

	public boolean commit() throws LoginException {
		 try {
			 
	            Life2UserPrincipal user = new Life2UserPrincipal(login);
	            Life2RolePrincipal role = null;
	            
	            if (this.roleid>PlatformUser.ROLE_USER && this.roleid<PlatformUser.ROLE_AREA_MANAGER)
	            {
	            	role=new Life2RolePrincipal("visitor");
	            	
	            }
	            else if (this.roleid>PlatformUser.ROLE_BIG_BUSINESS)
	            {
	            	role=new Life2RolePrincipal("admin");
	 
	            }
	            else
	            	throw new Exception("Acess not allowed for this role");
	            user.setRoleDescription(PlatformUser.roleNames[this.roleid]);
	            user.setTheUser(this.theUser);
	            subject.getPrincipals().add(user);
	            subject.getPrincipals().add(role);
	            
	            return true;
	 
	        } catch (Exception e) {
	 
	            throw new LoginException(e.getMessage());
	        }
	}

	public void initialize(Subject arg0, CallbackHandler arg1,
			Map<String, ?> arg2, Map<String, ?> arg3) {
        handler = arg1;
        subject = arg0;
	}

	public boolean login() throws LoginException {
		Callback[] callbacks = new Callback[2];
        callbacks[0] = new NameCallback("login");
        callbacks[1] = new PasswordCallback("password", true);
 
        try {
 
            handler.handle(callbacks);
            
            String name = ((NameCallback) callbacks[0]).getName();
            String password = String.valueOf(((PasswordCallback) callbacks[1]).getPassword());
            PlatformUserManager pm=new PlatformUserManager();
            this.userid=pm.login(name, password);
            if (userid<0) {
 
                throw new LoginException("Authentication failed");
            }
            login = name;
            PlatformUser pu=pm.getUser(name);
            if (pu.getRole()==PlatformUser.ROLE_REGION_ADMIN||pu.getRole()==PlatformUser.ROLE_COUNTRY_ADMIN||pu.getRole()==PlatformUser.ROLE_AREA_MANAGER||pu.getRole()==PlatformUser.ROLE_SYSTEM_ADMIN||pu.getRole()==PlatformUser.ROLE_BIG_BUSINESS||pu.getRole()==PlatformUser.ROLE_HUB||pu.getRole()==PlatformUser.ROLE_BUSINESS)
            {
            	this.roleid=pu.getRole();
            	this.theUser=pu;
            	return true;
            }
            else
            	throw new LoginException("This user has no access to this tool. An administrator role is needed.");
 
        } catch (IOException e) {
 
            throw new LoginException(e.getMessage());
 
        } catch (UnsupportedCallbackException e) {
 
            throw new LoginException(e.getMessage());
        }
        catch (ServiceException se ) 
        {
        	 throw new LoginException(se.getMessage());
        }
	}

	public boolean logout() throws LoginException {
		 
        try {
 
        	Life2UserPrincipal user = new Life2UserPrincipal(login);
        	Life2RolePrincipal role = new Life2RolePrincipal("admin");
 
            subject.getPrincipals().remove(user);
            subject.getPrincipals().remove(role);
 
            return true;
 
        } catch (Exception e) {
 
            throw new LoginException(e.getMessage());
        }
	}

}

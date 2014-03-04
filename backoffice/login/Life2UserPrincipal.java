/* Life 2.0 Backoffice code Copyright (C) 2014 - Fundació i2CAT This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA. */

package net.i2cat.csade.life2.backoffice.login;

import java.security.Principal;

import net.i2cat.csade.life2.backoffice.model.PlatformUser;


public class Life2UserPrincipal implements Principal {

	    String username;
	    String roleDescription;
	    PlatformUser theUser;
	    
	    
	    public PlatformUser getTheUser() {
			return theUser;
		}
		public void setTheUser(PlatformUser theUser) {
			this.theUser = theUser;
		}
		public Life2UserPrincipal(String name) {
	        username = name;
	    }
	    public String getName() {
	        return username;
	    }
	    
	    public String getRoleDescription() {
	    	return this.roleDescription;
	    }
	    
	    public void setRoleDescription(String roleDesc) {
	    	this.roleDescription=roleDesc;
	    }
	    
	    //Truqillo para evitar complicaciones
	    public String toString() {
	        return this.roleDescription;
	    }   
	 
	    public boolean equals(Object obj) {
	        if (this == obj) {
	            return true;
	        }   
	        if (obj instanceof Life2UserPrincipal) {
	        	Life2UserPrincipal other = (Life2UserPrincipal) obj;
	            return username.equals(other.username);
	        }   
	        return false;
	    }   
	 
	    public int hashCode() {
	        return username.hashCode();
	    }   
	

}

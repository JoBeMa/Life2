/* Life 2.0 Backoffice code Copyright (C) 2014 - Fundació i2CAT This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA. */

package net.i2cat.csade.life2.backoffice.login;

import java.security.Principal;

public class Life2RolePrincipal implements Principal {

	    String roleName;
	     
	    public Life2RolePrincipal(String name) {
	        roleName = name;
	    }
	    public String getName() {
	        return roleName;
	    }
	     
	    public String toString() {
	        return ("RolePrincipal: " + roleName);
	    }   
	 
	    public boolean equals(Object obj) {
	        if (this == obj) {
	            return true;
	        }   
	        if (obj instanceof Life2RolePrincipal) {
	        	Life2RolePrincipal other = (Life2RolePrincipal) obj;
	            return roleName.equals(other.roleName);
	        }   
	        return false;
	    }   
	 
	    public int hashCode() {
	        return roleName.hashCode();
	    }   
	

}

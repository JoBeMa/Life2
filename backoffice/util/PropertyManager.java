/* Life 2.0 Backoffice code Copyright (C) 2014 - Fundació i2CAT This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA. */

package net.i2cat.csade.life2.backoffice.util;
import java.util.ResourceBundle;

public class PropertyManager {
    private final static String WIN="win";
    private final static String UNIX="unix";
	
	private static PropertyManager instance;
	private ResourceBundle rb;
	
	private PropertyManager() {
		this.rb = ResourceBundle.getBundle("conf.life2backoffice");
	}
	
	public static PropertyManager getInstance() {
		if (instance==null) {
			instance = new PropertyManager();
		}
		return instance;
	}
	
	public String getValue(String name) {
		return rb.getString(name);
	}
	
	public String getUrlEngine()
	{
		return (getValue("url.engineService"));
	}
	
	public String getUrlDatabase() {
		return (getValue("url.databaseService"));
	}
	
	
	public String getOS() {		
		String os = System.getProperty("os.name");
		return (os.contains("Win")?WIN:UNIX); 
	}
	
	
	public String getSmtpServer(){
		return (getValue("mail.smtp.server"));
	}
	public String getSmtpServerPort(){
		return (getValue("mail.smtp.serverPort"));
	}

	public String getMailSupport(){	
		return (getValue("mail.supportAddress"));
	}
	
	public boolean useIdentification(){
		if (getValue("mail.smtp.useAuth")==null || "".endsWith(getValue("mail.smtp.useAuth")))
			return false;
		else
			return Boolean.parseBoolean((getValue("mail.smtp.useAuth")));
	}
	
	public String getSmtpUser(){	
		return (getValue("mail.smtp.user"));
	}
	
	public String getSmtpPwd(){	
		return (getValue("mail.smtp.pwd"));
	}	
	
	public boolean enableTLS(){
		if (getValue("mail.smtp.enableTLS")==null || "".endsWith(getValue("mail.smtp.enableTLS")))
			return false;
		else
			return (Boolean.parseBoolean(getValue("mail.smtp.enableTLS")));
	}	
	public boolean isSmtpDebug(){	
		return Boolean.parseBoolean(getValue("mail.smtp.debug"));
	}		
	
	
	public String getUserAdmin()
	{
		return(getValue("backoffice.user"));
	}
	
}

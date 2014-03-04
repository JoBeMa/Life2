/* Life 2.0 Backoffice code Copyright (C) 2014 - Fundació i2CAT This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA. */

package net.i2cat.csade.life2.backoffice.util;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.Properties;

import javax.servlet.ServletContext;

public class ChangablePropertiesManager {
	
	public static final String FILENAME="/WEB-INF/changableProperties.properties";
	
	private ServletContext context;
	private Properties p;
	
	public ChangablePropertiesManager(ServletContext context) {
		this.setContext(context);
		p = new Properties();
		String path=context.getRealPath( FILENAME );
		File f=new File(path);
		try 
		{
			if (f.exists())
				p.load(new FileInputStream(f));
			else
				f.createNewFile();
		} 
		catch (IOException ioe) 
		{
			System.out.println("error Saving properties file: " + ioe);
		}
	}
	
	public ServletContext getContext() {
		return context;
	}

	public void setContext(ServletContext context) {
		this.context = context;
	}
	
	public String getProperty(String property)
	{
		return p.getProperty(property);
	}
	
	public void saveProperty(String property,String value)
	{
		try {
			p.setProperty(property,value);
			p.store(new FileOutputStream(context.getRealPath( FILENAME )),null);
		} 
		catch (IOException ioe) 
		{
			System.out.println("error Saving properties file: " + ioe);
		}
	}
}

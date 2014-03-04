/* Life 2.0 Backoffice code Copyright (C) 2014 - Fundació i2CAT This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA. */

package net.i2cat.csade.life2.backoffice.util;

import javax.servlet.http.HttpServlet;
import org.hibernate.SQLQuery;
import org.hibernate.Session;


@SuppressWarnings("serial")
public class LoggedUsersCleaner extends HttpServlet {
	

	
    public void init() {
    	Session s = null;
		try{
			s=HibernateSessionFactory.getSession();
			s.beginTransaction();
			SQLQuery q=s.createSQLQuery("UPDATE User set logged=false where logged=true");
			q.executeUpdate();
			s.getTransaction().commit();
		}
		catch (Exception e) {
			//log.error(e.getMessage());
		}finally{
			
			if(s!=null)
				s.close();
		}
    	
    	
    }

}

/* Life 2.0 Backoffice code Copyright (C) 2014 - Fundació i2CAT This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA. */

package net.i2cat.csade.life2.backoffice.DAO;

import java.util.Iterator;
import java.util.List;
import org.hibernate.Criteria;
import org.hibernate.Session;
import org.hibernate.Transaction;
import org.hibernate.criterion.Restrictions;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import  net.i2cat.csade.life2.backoffice.model.Role;
import net.i2cat.csade.life2.backoffice.model.User;
import net.i2cat.csade.life2.backoffice.util.HibernateSessionFactory;

public class UserDAO {

	Logger log = LoggerFactory.getLogger(UserDAO.class);


	public long insert(User user) {
		long id = 0;
		Session s = null;
		Transaction tx=null;
		try{
			s=HibernateSessionFactory.getSession();
			tx=s.beginTransaction();
			s.saveOrUpdate(user);
			id = user.getIdUser();
			log.info("user with id: "+id+" saved");
			tx.commit();
		}
		catch (Exception e) {
			if(s!=null && tx!=null)
				tx.rollback();
			log.error(e.getMessage());
		}finally{
			if(s!=null)
				s.close();
		}
		return id;

	}

	public void delete(long idUser) {
		Session s = null;
		try{
			s=HibernateSessionFactory.getSession();
			s.beginTransaction();
			User user=(User)s.load(User.class, idUser);
			s.delete(user);
			s.getTransaction().commit();
		}
		catch (Exception e) {
			log.error(e.getMessage());
		}finally{
			if(s!=null)
				s.close();
		}

	}

	public User get(long idUser) {

		Session s = null;
		User user = null;
		try{
			s=HibernateSessionFactory.getSession();
			user = (User)s.get(User.class, idUser);
		}
		catch (Exception e) {
			log.error(e.getMessage());
		}finally{
			if(s!=null)
				s.close();
		}
		return user;
	}
	
	public Role addRole(User usuario, String role)
	{
		Session s = null;
		Role r=new Role();
		r.setRoleName(role);
		r.setUser(usuario.getUsername());
		try{
			s=HibernateSessionFactory.getSession();
			s.beginTransaction();
			s.saveOrUpdate(r);
			s.getTransaction().commit();
		}
		catch (Exception e) {
			log.error(e.getMessage());
		}finally{
			if(s!=null)
				s.close();
		}
		return r;		
	}

	@SuppressWarnings("unchecked")
	public void emptyRoles(User usuario)
	{
		Session s = null;
		List<Role> roles=null;
		try{
			s=HibernateSessionFactory.getSession();
			s.beginTransaction();
			Criteria c=s.createCriteria(Role.class);
			c.add(Restrictions.eq("username", usuario.getUsername()));
			roles=c.list();		
			Iterator<Role> it=roles.iterator();
			while(it.hasNext())
			{
				s.delete(it.next());
			}
			s.getTransaction().commit();
		}
		catch (Exception e) {
			log.error(e.getMessage());
		}finally{
			if(s!=null)
				s.close();
		}			
	}
	
	@SuppressWarnings("unchecked")
	public List<String> getRoles(User usuario)
	{
		Session s = null;
		List<String> roles=null;
		try{
			s=HibernateSessionFactory.getSession();
			s.beginTransaction();
			Criteria c=s.createCriteria(Role.class);
			c.add(Restrictions.eq("username", usuario.getUsername()));
			roles=c.list();			
		}
		catch (Exception e) {
			log.error(e.getMessage());
		}finally{
			if(s!=null)
				s.close();
		}
		return roles;		
	}


	public User update(User user) {	
		Session s = null;
		try{
			s=HibernateSessionFactory.getSession();
			s.beginTransaction();
			s.update(user);
			s.getTransaction().commit();
		}
		catch (Exception e) {
			log.error(e.getMessage());
		}finally{
			if(s!=null)
				s.close();
		}
		return user;
	}


	public User getByUser(String user) {

		User user_obj = null;
		Session s = null;
		try{
			s=HibernateSessionFactory.getSession();
			user_obj=(User) s.createCriteria(User.class).add(Restrictions.eq("username", user)).uniqueResult();
		}
		catch (Exception e) {
			log.error(e.getMessage());
		}finally{
			if(s!=null)
				s.close();
		}	
		return user_obj;
	}

	
	@SuppressWarnings("unchecked")
	public List<User> getAll()
	{
		Session s = null;
		List<User> users=null;
		try{
			s=HibernateSessionFactory.getSession();
			s.beginTransaction();
			Criteria c=s.createCriteria(User.class);
			users=c.list();			
		}
		catch (Exception e) {
			log.error(e.getMessage());
		}finally{
			if(s!=null)
				s.close();
		}
		return users;		
	}
	
	

public void updateActive(long idUser) {
	Session s = null;
	User person=null;
	try{
		s=HibernateSessionFactory.getSession();
		s.beginTransaction();
		person=(User)s.load(User.class, idUser);
		if(person!=null)
			person.setActive(!person.isActive());
		person.setNumTries(0);
		s.getTransaction().commit();
	}
	catch (Exception e) {
		log.error(e.getMessage());
	}finally{
		if(s!=null)
			s.close();
	}
}


}

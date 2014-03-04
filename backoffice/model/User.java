/* Life 2.0 Backoffice code Copyright (C) 2014 - Fundació i2CAT This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA. */

package net.i2cat.csade.life2.backoffice.model;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;

import net.i2cat.csade.life2.backoffice.DAO.UserDAO;
import net.i2cat.csade.life2.backoffice.util.PasswordGenerator;
import net.sf.json.JSONArray;
import net.sf.json.JSONObject;


@Entity
@Inheritance(strategy = InheritanceType.JOINED)
public class User implements JSONConvertible {
	
	public static int MAX_USER_TRIES=10;
	public final static int ROLE_DEMO_USER=0;
	public final static int ROLE_USER=1;
	public final static int ROLE_HUB=2;
	public final static int ROLE_BUSINESS=3;
	public final static int ROLE_BIG_BUSINESS=4;
	public final static int ROLE_AREA_MANAGER=5;
	public final static int ROLE_SYSTEM_ADMIN=6;
	public final static int ROLE_REGION_ADMIN=7;
	public final static int ROLE_COUNTRY_ADMIN=8;
	public final static String[] roleNames={"Demo User","User","Hub","Small Bussines","Big Business","Area Manager","System Admin","Regional Admin","Country Admin"};
	public static String[] USER_ROLES={"Demo User","User","Hub","Small Bussines","Big Business","Area Manager","System Admin","Regional Admin","Country Admin"};
	
	private long idUser;
	private String username;
	private String pass;
	private String name;
	private String surname;
	protected String email;

	private boolean active=true;
	protected int numTries=0;
	protected boolean logged;
	protected Calendar nextPasswordChange;
	protected Calendar lastLogin;
	protected int region;

	public int getRegion() {
		return region;
	}
	public void setRegion(int region) {
		this.region = region;
	}
	@Id
	@GeneratedValue
	public long getIdUser() {
		return idUser;
	}
	public void setIdUser(long id) {
		this.idUser = id;
	}
	
	@Column(unique = false, nullable = true)
	public Calendar getNextPasswordChange() {
		return nextPasswordChange;
	}

	public void setNextPasswordChange(Calendar nextPasswordChange) {
		this.nextPasswordChange = nextPasswordChange;
	}

	@Column(unique = false, nullable = false)	
	public int getNumTries() {
		return numTries;
	}

	public void setNumTries(int numTries) {
		this.numTries = numTries;
	}

	@Column(unique = false, nullable = false)	
	public boolean isLogged() {
		return logged;
	}

	public void setLogged(boolean logged) {
		this.logged = logged;
	}
	
	@Column(unique = false, nullable = true)	
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	
	@Column(unique = false, nullable = true)	
	public String getSurname() {
		return surname;
	}
	public void setSurname(String surname) {
		this.surname = surname;
	}

	@Column(unique = true, nullable = false)
	public String getUsername() {
		return username;
	}
	
	public void setUsername(String user_name) {
		this.username = user_name;
	}
	
	@Column(nullable=false)
	public String getPass() {
		return pass;
	}
	public void setPass(String pass) {
		this.pass =PasswordGenerator.createHash(pass);
	}
	
	public boolean isThePassword(String password)
	{
		return this.getPass().equals(PasswordGenerator.createHash(password));
	}
	
	@Column(unique = false, nullable = false)	
	public boolean isActive() {
		return active;
	}
	public void setActive(boolean active) {
		this.active = active;
	}	

	public void setEmail(String email) {
		this.email = email;
	}

	@Column(unique = false, nullable = false)
	public String getEmail() {
		return email;
	}	
	
	@Column(unique = false, nullable = true)
	public Calendar getLastLogin() {
		return lastLogin;
	}
	public void setLastLogin(Calendar lastLogin) {
		this.lastLogin = lastLogin;
	}	
	
	public JSONObject toJSON()
	{
		JSONObject jso=new JSONObject();
		SimpleDateFormat dt=new SimpleDateFormat("dd/MM/yyyy hh:mm");
        JSONArray row = new JSONArray();
        row.add(""+this.getIdUser());
        row.add(this.getUsername());
        row.add(this.getName());
        row.add(this.getSurname()==null?"":this.getSurname());
        row.add(this.getPass());
        if (this.getLastLogin()!=null)
        	row.add(dt.format(this.getLastLogin().getTime()));
        else
        	row.add("");
        row.add(this.getEmail());
        UserDAO ud=new UserDAO();
        List<String> l=ud.getRoles(this);
        if (l!=null && l.size()>0)
        	row.add(l.get(0));
        jso.put("aaData", row);
		return jso;
	}
	
	
}

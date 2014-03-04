/* Life 2.0 Backoffice code Copyright (C) 2014 - Fundació i2CAT This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA. */

package net.i2cat.csade.life2.backoffice.model;

import net.i2cat.csade.life2.backoffice.util.PasswordGenerator;
import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

public class PlatformUser implements JSONConvertible
{
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


   /* 0 =  User
    1 =  Promoter
    2 = Hub
    3 = Small_bussines
    4 = Technical_Admin
    5 = Moderator_Admin
    6 = Sys_Maintenance
*/
	int id_user;
	String login;
	String pass;
	String picture;
	String name;
	String email;
	String telephonenumber;
	String language;
	String home_area_lat;
	String home_area_lon;
	String home_area_rad;
	String last_location_timestamp;
	String last_location_lat;
	String last_location_lon;
	String notification_level;
	String promoter_id;
	String user_average_mark;
	String user_votes;
	int role;
	int enabled;
	boolean isNew;
	protected int region;

	public int getRegion() {
		return region;
	}
	public void setRegion(int region) {
		this.region = region;
	}
	
	public int getEnabled() {
		return enabled;
	}

	public void setEnabled(int enabled) {
		this.enabled = enabled;
	}

	public String getTelephonenumber() {
		return telephonenumber;
	}

	public void setTelephonenumber(String telephonenumber) {
		this.telephonenumber = telephonenumber;
	}

	public String getHome_area_rad() {
		return home_area_rad==null?"2":home_area_rad;
	}

	public void setHome_area_rad(String home_area_rad) {
		this.home_area_rad = home_area_rad;
	}	
	
	public boolean isNew() {
		return isNew;
	}

	public void setNew(boolean isNew) {
		this.isNew = isNew;
	}

	public int getRole() {
		return role;
	}

	public void setRole(int value) {
		this.role = value;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public int getId_user()
	{
		return id_user;
	}
	
	public void setId_user(int id)
	{
		this.id_user=id;
	}
	
	public String getLogin() {
		return login;
	}
	public void setLogin(String login) {
		this.login = login;
	}
	public String getPicture() {
		return picture;
	}
	public void setPicture(String picture) {
		this.picture = picture;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getLanguage() {
		return language;
	}
	public void setLanguage(String language) {
		this.language = language;
	}
	public String getHome_area_lat() {
		return home_area_lat;
	}
	public void setHome_area_lat(String home_area_lat) {
		this.home_area_lat = home_area_lat;
	}
	public String getHome_area_lon() {
		return home_area_lon;
	}
	public void setHome_area_lon(String home_area_lon) {
		this.home_area_lon = home_area_lon;
	}
	public String getLast_location_timestamp() {
		return last_location_timestamp;
	}
	public void setLast_location_timestamp(String last_location_timestamp) {
		this.last_location_timestamp = last_location_timestamp;
	}
	public String getLast_location_lat() {
		return last_location_lat;
	}
	public void setLast_location_lat(String last_location_lat) {
		this.last_location_lat = last_location_lat;
	}
	public String getLast_location_lon() {
		return last_location_lon;
	}
	public void setLast_location_lon(String last_location_lon) {
		this.last_location_lon = last_location_lon;
	}
	public String getNotification_level() {
		return notification_level;
	}
	public void setNotification_level(String notification_level) {
		this.notification_level = notification_level;
	}
	public String getPromoter_id() {
		return promoter_id;
	}
	public void setPromoter_id(String promoter_id) {
		this.promoter_id = promoter_id;
	}
	public String getUser_average_mark() {
		return user_average_mark;
	}
	public void setUser_average_mark(String user_average_mark) {
		this.user_average_mark = user_average_mark;
	}
	public String getUser_votes() {
		return user_votes;
	}
	public void setUser_votes(String user_votes) {
		this.user_votes = user_votes;
	}

	public String getPass() {
		return pass;
	}

	public void setPass(String pass) {
		this.pass = pass;
	}

	public JSONObject toJSON() {
		JSONObject jso=new JSONObject();
        JSONArray row = new JSONArray();
        row.add(this.getLogin());
        if(this.getName()!=null)
        {
        	row.add(PasswordGenerator.isoEncoder(this.getName()));
        	//row.add(StringEscapeUtils.escapeHtml(this.getName()));
        	//row.add(this.getName().replaceAll("‡", "&aacute;").replaceAll("Ž", "&eacute;").replaceAll("’", "&iacute;").replaceAll("—", "&oacute;").replaceAll("œ", "&uacute;").replaceAll("–", "&ntilde;"));
        }
        row.add(this.getEmail());
        row.add(this.getRole());
        row.add(this.getLanguage()); 
        if (this.getPicture()!=null && !"".equals(this.getPicture()))
        	row.add(this.getPicture()); 
        else
        	row.add("/LifeBackOffice/img/no_picture.jpg");
        row.add(this.getNotification_level());
        row.add(this.getPromoter_id());
        row.add(this.getUser_average_mark());
        row.add(this.getUser_votes());        
        row.add(this.getHome_area_lat());
        row.add(this.getHome_area_lon());
        row.add(this.getLast_location_timestamp());
        row.add(this.getLast_location_lat());
        row.add(this.getLast_location_lon());
        row.add(""+this.getEnabled());
        row.add(this.getTelephonenumber());
        jso.put("aaData", row);
		return jso;
	}
}

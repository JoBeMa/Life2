/**
 * UserProfile.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package net.i2cat.csade.life2.backoffice.clientws.b.dbservice;

public class UserProfile  implements java.io.Serializable {
    private int user_id;

    private java.lang.String login;

    private int role;

    private java.lang.String password;

    private java.lang.String name;

    private java.lang.String email;

    private java.lang.String telephonenumber;

    private java.lang.String picture;

    private java.lang.String language;

    private java.lang.String home_area_lat;

    private java.lang.String home_area_lon;

    private java.lang.String home_area_radius;

    private java.lang.String last_location_timestamp;

    private java.lang.String last_location_lat;

    private java.lang.String last_location_lon;

    private java.lang.String notification_level;

    private java.lang.String promoter_id;

    private java.lang.String user_average_mark;

    private java.lang.String user_votes;

    private int enabled;

    private long distance;

    private java.lang.String region;

    private java.lang.String address;

    private java.lang.String adminRegion;

    public UserProfile() {
    }

    public UserProfile(
           int user_id,
           java.lang.String login,
           int role,
           java.lang.String password,
           java.lang.String name,
           java.lang.String email,
           java.lang.String telephonenumber,
           java.lang.String picture,
           java.lang.String language,
           java.lang.String home_area_lat,
           java.lang.String home_area_lon,
           java.lang.String home_area_radius,
           java.lang.String last_location_timestamp,
           java.lang.String last_location_lat,
           java.lang.String last_location_lon,
           java.lang.String notification_level,
           java.lang.String promoter_id,
           java.lang.String user_average_mark,
           java.lang.String user_votes,
           int enabled,
           long distance,
           java.lang.String region,
           java.lang.String address,
           java.lang.String adminRegion) {
           this.user_id = user_id;
           this.login = login;
           this.role = role;
           this.password = password;
           this.name = name;
           this.email = email;
           this.telephonenumber = telephonenumber;
           this.picture = picture;
           this.language = language;
           this.home_area_lat = home_area_lat;
           this.home_area_lon = home_area_lon;
           this.home_area_radius = home_area_radius;
           this.last_location_timestamp = last_location_timestamp;
           this.last_location_lat = last_location_lat;
           this.last_location_lon = last_location_lon;
           this.notification_level = notification_level;
           this.promoter_id = promoter_id;
           this.user_average_mark = user_average_mark;
           this.user_votes = user_votes;
           this.enabled = enabled;
           this.distance = distance;
           this.region = region;
           this.address = address;
           this.adminRegion = adminRegion;
    }


    /**
     * Gets the user_id value for this UserProfile.
     * 
     * @return user_id
     */
    public int getUser_id() {
        return user_id;
    }


    /**
     * Sets the user_id value for this UserProfile.
     * 
     * @param user_id
     */
    public void setUser_id(int user_id) {
        this.user_id = user_id;
    }


    /**
     * Gets the login value for this UserProfile.
     * 
     * @return login
     */
    public java.lang.String getLogin() {
        return login;
    }


    /**
     * Sets the login value for this UserProfile.
     * 
     * @param login
     */
    public void setLogin(java.lang.String login) {
        this.login = login;
    }


    /**
     * Gets the role value for this UserProfile.
     * 
     * @return role
     */
    public int getRole() {
        return role;
    }


    /**
     * Sets the role value for this UserProfile.
     * 
     * @param role
     */
    public void setRole(int role) {
        this.role = role;
    }


    /**
     * Gets the password value for this UserProfile.
     * 
     * @return password
     */
    public java.lang.String getPassword() {
        return password;
    }


    /**
     * Sets the password value for this UserProfile.
     * 
     * @param password
     */
    public void setPassword(java.lang.String password) {
        this.password = password;
    }


    /**
     * Gets the name value for this UserProfile.
     * 
     * @return name
     */
    public java.lang.String getName() {
        return name;
    }


    /**
     * Sets the name value for this UserProfile.
     * 
     * @param name
     */
    public void setName(java.lang.String name) {
        this.name = name;
    }


    /**
     * Gets the email value for this UserProfile.
     * 
     * @return email
     */
    public java.lang.String getEmail() {
        return email;
    }


    /**
     * Sets the email value for this UserProfile.
     * 
     * @param email
     */
    public void setEmail(java.lang.String email) {
        this.email = email;
    }


    /**
     * Gets the telephonenumber value for this UserProfile.
     * 
     * @return telephonenumber
     */
    public java.lang.String getTelephonenumber() {
        return telephonenumber;
    }


    /**
     * Sets the telephonenumber value for this UserProfile.
     * 
     * @param telephonenumber
     */
    public void setTelephonenumber(java.lang.String telephonenumber) {
        this.telephonenumber = telephonenumber;
    }


    /**
     * Gets the picture value for this UserProfile.
     * 
     * @return picture
     */
    public java.lang.String getPicture() {
        return picture;
    }


    /**
     * Sets the picture value for this UserProfile.
     * 
     * @param picture
     */
    public void setPicture(java.lang.String picture) {
        this.picture = picture;
    }


    /**
     * Gets the language value for this UserProfile.
     * 
     * @return language
     */
    public java.lang.String getLanguage() {
        return language;
    }


    /**
     * Sets the language value for this UserProfile.
     * 
     * @param language
     */
    public void setLanguage(java.lang.String language) {
        this.language = language;
    }


    /**
     * Gets the home_area_lat value for this UserProfile.
     * 
     * @return home_area_lat
     */
    public java.lang.String getHome_area_lat() {
        return home_area_lat;
    }


    /**
     * Sets the home_area_lat value for this UserProfile.
     * 
     * @param home_area_lat
     */
    public void setHome_area_lat(java.lang.String home_area_lat) {
        this.home_area_lat = home_area_lat;
    }


    /**
     * Gets the home_area_lon value for this UserProfile.
     * 
     * @return home_area_lon
     */
    public java.lang.String getHome_area_lon() {
        return home_area_lon;
    }


    /**
     * Sets the home_area_lon value for this UserProfile.
     * 
     * @param home_area_lon
     */
    public void setHome_area_lon(java.lang.String home_area_lon) {
        this.home_area_lon = home_area_lon;
    }


    /**
     * Gets the home_area_radius value for this UserProfile.
     * 
     * @return home_area_radius
     */
    public java.lang.String getHome_area_radius() {
        return home_area_radius;
    }


    /**
     * Sets the home_area_radius value for this UserProfile.
     * 
     * @param home_area_radius
     */
    public void setHome_area_radius(java.lang.String home_area_radius) {
        this.home_area_radius = home_area_radius;
    }


    /**
     * Gets the last_location_timestamp value for this UserProfile.
     * 
     * @return last_location_timestamp
     */
    public java.lang.String getLast_location_timestamp() {
        return last_location_timestamp;
    }


    /**
     * Sets the last_location_timestamp value for this UserProfile.
     * 
     * @param last_location_timestamp
     */
    public void setLast_location_timestamp(java.lang.String last_location_timestamp) {
        this.last_location_timestamp = last_location_timestamp;
    }


    /**
     * Gets the last_location_lat value for this UserProfile.
     * 
     * @return last_location_lat
     */
    public java.lang.String getLast_location_lat() {
        return last_location_lat;
    }


    /**
     * Sets the last_location_lat value for this UserProfile.
     * 
     * @param last_location_lat
     */
    public void setLast_location_lat(java.lang.String last_location_lat) {
        this.last_location_lat = last_location_lat;
    }


    /**
     * Gets the last_location_lon value for this UserProfile.
     * 
     * @return last_location_lon
     */
    public java.lang.String getLast_location_lon() {
        return last_location_lon;
    }


    /**
     * Sets the last_location_lon value for this UserProfile.
     * 
     * @param last_location_lon
     */
    public void setLast_location_lon(java.lang.String last_location_lon) {
        this.last_location_lon = last_location_lon;
    }


    /**
     * Gets the notification_level value for this UserProfile.
     * 
     * @return notification_level
     */
    public java.lang.String getNotification_level() {
        return notification_level;
    }


    /**
     * Sets the notification_level value for this UserProfile.
     * 
     * @param notification_level
     */
    public void setNotification_level(java.lang.String notification_level) {
        this.notification_level = notification_level;
    }


    /**
     * Gets the promoter_id value for this UserProfile.
     * 
     * @return promoter_id
     */
    public java.lang.String getPromoter_id() {
        return promoter_id;
    }


    /**
     * Sets the promoter_id value for this UserProfile.
     * 
     * @param promoter_id
     */
    public void setPromoter_id(java.lang.String promoter_id) {
        this.promoter_id = promoter_id;
    }


    /**
     * Gets the user_average_mark value for this UserProfile.
     * 
     * @return user_average_mark
     */
    public java.lang.String getUser_average_mark() {
        return user_average_mark;
    }


    /**
     * Sets the user_average_mark value for this UserProfile.
     * 
     * @param user_average_mark
     */
    public void setUser_average_mark(java.lang.String user_average_mark) {
        this.user_average_mark = user_average_mark;
    }


    /**
     * Gets the user_votes value for this UserProfile.
     * 
     * @return user_votes
     */
    public java.lang.String getUser_votes() {
        return user_votes;
    }


    /**
     * Sets the user_votes value for this UserProfile.
     * 
     * @param user_votes
     */
    public void setUser_votes(java.lang.String user_votes) {
        this.user_votes = user_votes;
    }


    /**
     * Gets the enabled value for this UserProfile.
     * 
     * @return enabled
     */
    public int getEnabled() {
        return enabled;
    }


    /**
     * Sets the enabled value for this UserProfile.
     * 
     * @param enabled
     */
    public void setEnabled(int enabled) {
        this.enabled = enabled;
    }


    /**
     * Gets the distance value for this UserProfile.
     * 
     * @return distance
     */
    public long getDistance() {
        return distance;
    }


    /**
     * Sets the distance value for this UserProfile.
     * 
     * @param distance
     */
    public void setDistance(long distance) {
        this.distance = distance;
    }


    /**
     * Gets the region value for this UserProfile.
     * 
     * @return region
     */
    public java.lang.String getRegion() {
        return region;
    }


    /**
     * Sets the region value for this UserProfile.
     * 
     * @param region
     */
    public void setRegion(java.lang.String region) {
        this.region = region;
    }


    /**
     * Gets the address value for this UserProfile.
     * 
     * @return address
     */
    public java.lang.String getAddress() {
        return address;
    }


    /**
     * Sets the address value for this UserProfile.
     * 
     * @param address
     */
    public void setAddress(java.lang.String address) {
        this.address = address;
    }


    /**
     * Gets the adminRegion value for this UserProfile.
     * 
     * @return adminRegion
     */
    public java.lang.String getAdminRegion() {
        return adminRegion;
    }


    /**
     * Sets the adminRegion value for this UserProfile.
     * 
     * @param adminRegion
     */
    public void setAdminRegion(java.lang.String adminRegion) {
        this.adminRegion = adminRegion;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof UserProfile)) return false;
        UserProfile other = (UserProfile) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            this.user_id == other.getUser_id() &&
            ((this.login==null && other.getLogin()==null) || 
             (this.login!=null &&
              this.login.equals(other.getLogin()))) &&
            this.role == other.getRole() &&
            ((this.password==null && other.getPassword()==null) || 
             (this.password!=null &&
              this.password.equals(other.getPassword()))) &&
            ((this.name==null && other.getName()==null) || 
             (this.name!=null &&
              this.name.equals(other.getName()))) &&
            ((this.email==null && other.getEmail()==null) || 
             (this.email!=null &&
              this.email.equals(other.getEmail()))) &&
            ((this.telephonenumber==null && other.getTelephonenumber()==null) || 
             (this.telephonenumber!=null &&
              this.telephonenumber.equals(other.getTelephonenumber()))) &&
            ((this.picture==null && other.getPicture()==null) || 
             (this.picture!=null &&
              this.picture.equals(other.getPicture()))) &&
            ((this.language==null && other.getLanguage()==null) || 
             (this.language!=null &&
              this.language.equals(other.getLanguage()))) &&
            ((this.home_area_lat==null && other.getHome_area_lat()==null) || 
             (this.home_area_lat!=null &&
              this.home_area_lat.equals(other.getHome_area_lat()))) &&
            ((this.home_area_lon==null && other.getHome_area_lon()==null) || 
             (this.home_area_lon!=null &&
              this.home_area_lon.equals(other.getHome_area_lon()))) &&
            ((this.home_area_radius==null && other.getHome_area_radius()==null) || 
             (this.home_area_radius!=null &&
              this.home_area_radius.equals(other.getHome_area_radius()))) &&
            ((this.last_location_timestamp==null && other.getLast_location_timestamp()==null) || 
             (this.last_location_timestamp!=null &&
              this.last_location_timestamp.equals(other.getLast_location_timestamp()))) &&
            ((this.last_location_lat==null && other.getLast_location_lat()==null) || 
             (this.last_location_lat!=null &&
              this.last_location_lat.equals(other.getLast_location_lat()))) &&
            ((this.last_location_lon==null && other.getLast_location_lon()==null) || 
             (this.last_location_lon!=null &&
              this.last_location_lon.equals(other.getLast_location_lon()))) &&
            ((this.notification_level==null && other.getNotification_level()==null) || 
             (this.notification_level!=null &&
              this.notification_level.equals(other.getNotification_level()))) &&
            ((this.promoter_id==null && other.getPromoter_id()==null) || 
             (this.promoter_id!=null &&
              this.promoter_id.equals(other.getPromoter_id()))) &&
            ((this.user_average_mark==null && other.getUser_average_mark()==null) || 
             (this.user_average_mark!=null &&
              this.user_average_mark.equals(other.getUser_average_mark()))) &&
            ((this.user_votes==null && other.getUser_votes()==null) || 
             (this.user_votes!=null &&
              this.user_votes.equals(other.getUser_votes()))) &&
            this.enabled == other.getEnabled() &&
            this.distance == other.getDistance() &&
            ((this.region==null && other.getRegion()==null) || 
             (this.region!=null &&
              this.region.equals(other.getRegion()))) &&
            ((this.address==null && other.getAddress()==null) || 
             (this.address!=null &&
              this.address.equals(other.getAddress()))) &&
            ((this.adminRegion==null && other.getAdminRegion()==null) || 
             (this.adminRegion!=null &&
              this.adminRegion.equals(other.getAdminRegion())));
        __equalsCalc = null;
        return _equals;
    }

    private boolean __hashCodeCalc = false;
    public synchronized int hashCode() {
        if (__hashCodeCalc) {
            return 0;
        }
        __hashCodeCalc = true;
        int _hashCode = 1;
        _hashCode += getUser_id();
        if (getLogin() != null) {
            _hashCode += getLogin().hashCode();
        }
        _hashCode += getRole();
        if (getPassword() != null) {
            _hashCode += getPassword().hashCode();
        }
        if (getName() != null) {
            _hashCode += getName().hashCode();
        }
        if (getEmail() != null) {
            _hashCode += getEmail().hashCode();
        }
        if (getTelephonenumber() != null) {
            _hashCode += getTelephonenumber().hashCode();
        }
        if (getPicture() != null) {
            _hashCode += getPicture().hashCode();
        }
        if (getLanguage() != null) {
            _hashCode += getLanguage().hashCode();
        }
        if (getHome_area_lat() != null) {
            _hashCode += getHome_area_lat().hashCode();
        }
        if (getHome_area_lon() != null) {
            _hashCode += getHome_area_lon().hashCode();
        }
        if (getHome_area_radius() != null) {
            _hashCode += getHome_area_radius().hashCode();
        }
        if (getLast_location_timestamp() != null) {
            _hashCode += getLast_location_timestamp().hashCode();
        }
        if (getLast_location_lat() != null) {
            _hashCode += getLast_location_lat().hashCode();
        }
        if (getLast_location_lon() != null) {
            _hashCode += getLast_location_lon().hashCode();
        }
        if (getNotification_level() != null) {
            _hashCode += getNotification_level().hashCode();
        }
        if (getPromoter_id() != null) {
            _hashCode += getPromoter_id().hashCode();
        }
        if (getUser_average_mark() != null) {
            _hashCode += getUser_average_mark().hashCode();
        }
        if (getUser_votes() != null) {
            _hashCode += getUser_votes().hashCode();
        }
        _hashCode += getEnabled();
        _hashCode += new Long(getDistance()).hashCode();
        if (getRegion() != null) {
            _hashCode += getRegion().hashCode();
        }
        if (getAddress() != null) {
            _hashCode += getAddress().hashCode();
        }
        if (getAdminRegion() != null) {
            _hashCode += getAdminRegion().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(UserProfile.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://Life_2_0_DB/", "UserProfile"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("user_id");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "User_id"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("login");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Login"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("role");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Role"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("password");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Password"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("name");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Name"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("email");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Email"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("telephonenumber");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "telephonenumber"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("picture");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Picture"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("language");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Language"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("home_area_lat");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_lat"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("home_area_lon");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_lon"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("home_area_radius");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_radius"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("last_location_timestamp");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_timestamp"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("last_location_lat");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_lat"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("last_location_lon");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_lon"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("notification_level");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Notification_level"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("promoter_id");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Promoter_id"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("user_average_mark");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "User_average_mark"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("user_votes");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "User_votes"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("enabled");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Enabled"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("distance");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Distance"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "long"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("region");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "region"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("address");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "address"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("adminRegion");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "adminRegion"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
    }

    /**
     * Return type metadata object
     */
    public static org.apache.axis.description.TypeDesc getTypeDesc() {
        return typeDesc;
    }

    /**
     * Get Custom Serializer
     */
    public static org.apache.axis.encoding.Serializer getSerializer(
           java.lang.String mechType, 
           java.lang.Class _javaType,  
           javax.xml.namespace.QName _xmlType) {
        return 
          new  org.apache.axis.encoding.ser.BeanSerializer(
            _javaType, _xmlType, typeDesc);
    }

    /**
     * Get Custom Deserializer
     */
    public static org.apache.axis.encoding.Deserializer getDeserializer(
           java.lang.String mechType, 
           java.lang.Class _javaType,  
           javax.xml.namespace.QName _xmlType) {
        return 
          new  org.apache.axis.encoding.ser.BeanDeserializer(
            _javaType, _xmlType, typeDesc);
    }

}

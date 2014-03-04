/**
 * Stats.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package net.i2cat.csade.life2.backoffice.clientws.a.engservice;

public class Stats  implements java.io.Serializable {
    private int event_Id;

    private java.lang.String user_Login;

    private java.lang.String dTime;

    private int duration;

    private java.lang.String device;

    private java.lang.String query;

    private java.lang.String lat;

    private java.lang.String lon;

    private long distance;

    public Stats() {
    }

    public Stats(
           int event_Id,
           java.lang.String user_Login,
           java.lang.String dTime,
           int duration,
           java.lang.String device,
           java.lang.String query,
           java.lang.String lat,
           java.lang.String lon,
           long distance) {
           this.event_Id = event_Id;
           this.user_Login = user_Login;
           this.dTime = dTime;
           this.duration = duration;
           this.device = device;
           this.query = query;
           this.lat = lat;
           this.lon = lon;
           this.distance = distance;
    }


    /**
     * Gets the event_Id value for this Stats.
     * 
     * @return event_Id
     */
    public int getEvent_Id() {
        return event_Id;
    }


    /**
     * Sets the event_Id value for this Stats.
     * 
     * @param event_Id
     */
    public void setEvent_Id(int event_Id) {
        this.event_Id = event_Id;
    }


    /**
     * Gets the user_Login value for this Stats.
     * 
     * @return user_Login
     */
    public java.lang.String getUser_Login() {
        return user_Login;
    }


    /**
     * Sets the user_Login value for this Stats.
     * 
     * @param user_Login
     */
    public void setUser_Login(java.lang.String user_Login) {
        this.user_Login = user_Login;
    }


    /**
     * Gets the dTime value for this Stats.
     * 
     * @return dTime
     */
    public java.lang.String getDTime() {
        return dTime;
    }


    /**
     * Sets the dTime value for this Stats.
     * 
     * @param dTime
     */
    public void setDTime(java.lang.String dTime) {
        this.dTime = dTime;
    }


    /**
     * Gets the duration value for this Stats.
     * 
     * @return duration
     */
    public int getDuration() {
        return duration;
    }


    /**
     * Sets the duration value for this Stats.
     * 
     * @param duration
     */
    public void setDuration(int duration) {
        this.duration = duration;
    }


    /**
     * Gets the device value for this Stats.
     * 
     * @return device
     */
    public java.lang.String getDevice() {
        return device;
    }


    /**
     * Sets the device value for this Stats.
     * 
     * @param device
     */
    public void setDevice(java.lang.String device) {
        this.device = device;
    }


    /**
     * Gets the query value for this Stats.
     * 
     * @return query
     */
    public java.lang.String getQuery() {
        return query;
    }


    /**
     * Sets the query value for this Stats.
     * 
     * @param query
     */
    public void setQuery(java.lang.String query) {
        this.query = query;
    }


    /**
     * Gets the lat value for this Stats.
     * 
     * @return lat
     */
    public java.lang.String getLat() {
        return lat;
    }


    /**
     * Sets the lat value for this Stats.
     * 
     * @param lat
     */
    public void setLat(java.lang.String lat) {
        this.lat = lat;
    }


    /**
     * Gets the lon value for this Stats.
     * 
     * @return lon
     */
    public java.lang.String getLon() {
        return lon;
    }


    /**
     * Sets the lon value for this Stats.
     * 
     * @param lon
     */
    public void setLon(java.lang.String lon) {
        this.lon = lon;
    }


    /**
     * Gets the distance value for this Stats.
     * 
     * @return distance
     */
    public long getDistance() {
        return distance;
    }


    /**
     * Sets the distance value for this Stats.
     * 
     * @param distance
     */
    public void setDistance(long distance) {
        this.distance = distance;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof Stats)) return false;
        Stats other = (Stats) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            this.event_Id == other.getEvent_Id() &&
            ((this.user_Login==null && other.getUser_Login()==null) || 
             (this.user_Login!=null &&
              this.user_Login.equals(other.getUser_Login()))) &&
            ((this.dTime==null && other.getDTime()==null) || 
             (this.dTime!=null &&
              this.dTime.equals(other.getDTime()))) &&
            this.duration == other.getDuration() &&
            ((this.device==null && other.getDevice()==null) || 
             (this.device!=null &&
              this.device.equals(other.getDevice()))) &&
            ((this.query==null && other.getQuery()==null) || 
             (this.query!=null &&
              this.query.equals(other.getQuery()))) &&
            ((this.lat==null && other.getLat()==null) || 
             (this.lat!=null &&
              this.lat.equals(other.getLat()))) &&
            ((this.lon==null && other.getLon()==null) || 
             (this.lon!=null &&
              this.lon.equals(other.getLon()))) &&
            this.distance == other.getDistance();
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
        _hashCode += getEvent_Id();
        if (getUser_Login() != null) {
            _hashCode += getUser_Login().hashCode();
        }
        if (getDTime() != null) {
            _hashCode += getDTime().hashCode();
        }
        _hashCode += getDuration();
        if (getDevice() != null) {
            _hashCode += getDevice().hashCode();
        }
        if (getQuery() != null) {
            _hashCode += getQuery().hashCode();
        }
        if (getLat() != null) {
            _hashCode += getLat().hashCode();
        }
        if (getLon() != null) {
            _hashCode += getLon().hashCode();
        }
        _hashCode += new Long(getDistance()).hashCode();
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(Stats.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Stats"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("event_Id");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Event_Id"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("user_Login");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "User_Login"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("DTime");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "dTime"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("duration");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Duration"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("device");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Device"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("query");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Query"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("lat");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Lat"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("lon");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Lon"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("distance");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Distance"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "long"));
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

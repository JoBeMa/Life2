/**
 * ObjStats.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package net.i2cat.csade.life2.backoffice.clientws.b.engservice;

public class ObjStats  implements java.io.Serializable {
    private int idStat;

    private int iEvent;

    private java.lang.String user_Login;

    private java.lang.String dTime;

    private int duration;

    private java.lang.String lat;

    private java.lang.String lon;

    private java.lang.String device;

    private java.lang.String query;

    private java.lang.String lng;

    public ObjStats() {
    }

    public ObjStats(
           int idStat,
           int iEvent,
           java.lang.String user_Login,
           java.lang.String dTime,
           int duration,
           java.lang.String lat,
           java.lang.String lon,
           java.lang.String device,
           java.lang.String query,
           java.lang.String lng) {
           this.idStat = idStat;
           this.iEvent = iEvent;
           this.user_Login = user_Login;
           this.dTime = dTime;
           this.duration = duration;
           this.lat = lat;
           this.lon = lon;
           this.device = device;
           this.query = query;
           this.lng = lng;
    }


    /**
     * Gets the idStat value for this ObjStats.
     * 
     * @return idStat
     */
    public int getIdStat() {
        return idStat;
    }


    /**
     * Sets the idStat value for this ObjStats.
     * 
     * @param idStat
     */
    public void setIdStat(int idStat) {
        this.idStat = idStat;
    }


    /**
     * Gets the iEvent value for this ObjStats.
     * 
     * @return iEvent
     */
    public int getIEvent() {
        return iEvent;
    }


    /**
     * Sets the iEvent value for this ObjStats.
     * 
     * @param iEvent
     */
    public void setIEvent(int iEvent) {
        this.iEvent = iEvent;
    }


    /**
     * Gets the user_Login value for this ObjStats.
     * 
     * @return user_Login
     */
    public java.lang.String getUser_Login() {
        return user_Login;
    }


    /**
     * Sets the user_Login value for this ObjStats.
     * 
     * @param user_Login
     */
    public void setUser_Login(java.lang.String user_Login) {
        this.user_Login = user_Login;
    }


    /**
     * Gets the dTime value for this ObjStats.
     * 
     * @return dTime
     */
    public java.lang.String getDTime() {
        return dTime;
    }


    /**
     * Sets the dTime value for this ObjStats.
     * 
     * @param dTime
     */
    public void setDTime(java.lang.String dTime) {
        this.dTime = dTime;
    }


    /**
     * Gets the duration value for this ObjStats.
     * 
     * @return duration
     */
    public int getDuration() {
        return duration;
    }


    /**
     * Sets the duration value for this ObjStats.
     * 
     * @param duration
     */
    public void setDuration(int duration) {
        this.duration = duration;
    }


    /**
     * Gets the lat value for this ObjStats.
     * 
     * @return lat
     */
    public java.lang.String getLat() {
        return lat;
    }


    /**
     * Sets the lat value for this ObjStats.
     * 
     * @param lat
     */
    public void setLat(java.lang.String lat) {
        this.lat = lat;
    }


    /**
     * Gets the lon value for this ObjStats.
     * 
     * @return lon
     */
    public java.lang.String getLon() {
        return lon;
    }


    /**
     * Sets the lon value for this ObjStats.
     * 
     * @param lon
     */
    public void setLon(java.lang.String lon) {
        this.lon = lon;
    }


    /**
     * Gets the device value for this ObjStats.
     * 
     * @return device
     */
    public java.lang.String getDevice() {
        return device;
    }


    /**
     * Sets the device value for this ObjStats.
     * 
     * @param device
     */
    public void setDevice(java.lang.String device) {
        this.device = device;
    }


    /**
     * Gets the query value for this ObjStats.
     * 
     * @return query
     */
    public java.lang.String getQuery() {
        return query;
    }


    /**
     * Sets the query value for this ObjStats.
     * 
     * @param query
     */
    public void setQuery(java.lang.String query) {
        this.query = query;
    }


    /**
     * Gets the lng value for this ObjStats.
     * 
     * @return lng
     */
    public java.lang.String getLng() {
        return lng;
    }


    /**
     * Sets the lng value for this ObjStats.
     * 
     * @param lng
     */
    public void setLng(java.lang.String lng) {
        this.lng = lng;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof ObjStats)) return false;
        ObjStats other = (ObjStats) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            this.idStat == other.getIdStat() &&
            this.iEvent == other.getIEvent() &&
            ((this.user_Login==null && other.getUser_Login()==null) || 
             (this.user_Login!=null &&
              this.user_Login.equals(other.getUser_Login()))) &&
            ((this.dTime==null && other.getDTime()==null) || 
             (this.dTime!=null &&
              this.dTime.equals(other.getDTime()))) &&
            this.duration == other.getDuration() &&
            ((this.lat==null && other.getLat()==null) || 
             (this.lat!=null &&
              this.lat.equals(other.getLat()))) &&
            ((this.lon==null && other.getLon()==null) || 
             (this.lon!=null &&
              this.lon.equals(other.getLon()))) &&
            ((this.device==null && other.getDevice()==null) || 
             (this.device!=null &&
              this.device.equals(other.getDevice()))) &&
            ((this.query==null && other.getQuery()==null) || 
             (this.query!=null &&
              this.query.equals(other.getQuery()))) &&
            ((this.lng==null && other.getLng()==null) || 
             (this.lng!=null &&
              this.lng.equals(other.getLng())));
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
        _hashCode += getIdStat();
        _hashCode += getIEvent();
        if (getUser_Login() != null) {
            _hashCode += getUser_Login().hashCode();
        }
        if (getDTime() != null) {
            _hashCode += getDTime().hashCode();
        }
        _hashCode += getDuration();
        if (getLat() != null) {
            _hashCode += getLat().hashCode();
        }
        if (getLon() != null) {
            _hashCode += getLon().hashCode();
        }
        if (getDevice() != null) {
            _hashCode += getDevice().hashCode();
        }
        if (getQuery() != null) {
            _hashCode += getQuery().hashCode();
        }
        if (getLng() != null) {
            _hashCode += getLng().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(ObjStats.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "ObjStats"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("idStat");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "idStat"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("IEvent");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "iEvent"));
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
        elemField.setFieldName("lng");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "lng"));
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

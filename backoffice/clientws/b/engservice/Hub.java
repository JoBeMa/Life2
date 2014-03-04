/**
 * Hub.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package net.i2cat.csade.life2.backoffice.clientws.b.engservice;

public class Hub  implements java.io.Serializable {
    private int hub_id;

    private int user_id;

    private java.lang.String name;

    private int area;

    private double hub_average_mark;

    private int hub_votes;

    private java.lang.String lng;

    private int category;

    private java.lang.String address;

    public Hub() {
    }

    public Hub(
           int hub_id,
           int user_id,
           java.lang.String name,
           int area,
           double hub_average_mark,
           int hub_votes,
           java.lang.String lng,
           int category,
           java.lang.String address) {
           this.hub_id = hub_id;
           this.user_id = user_id;
           this.name = name;
           this.area = area;
           this.hub_average_mark = hub_average_mark;
           this.hub_votes = hub_votes;
           this.lng = lng;
           this.category = category;
           this.address = address;
    }


    /**
     * Gets the hub_id value for this Hub.
     * 
     * @return hub_id
     */
    public int getHub_id() {
        return hub_id;
    }


    /**
     * Sets the hub_id value for this Hub.
     * 
     * @param hub_id
     */
    public void setHub_id(int hub_id) {
        this.hub_id = hub_id;
    }


    /**
     * Gets the user_id value for this Hub.
     * 
     * @return user_id
     */
    public int getUser_id() {
        return user_id;
    }


    /**
     * Sets the user_id value for this Hub.
     * 
     * @param user_id
     */
    public void setUser_id(int user_id) {
        this.user_id = user_id;
    }


    /**
     * Gets the name value for this Hub.
     * 
     * @return name
     */
    public java.lang.String getName() {
        return name;
    }


    /**
     * Sets the name value for this Hub.
     * 
     * @param name
     */
    public void setName(java.lang.String name) {
        this.name = name;
    }


    /**
     * Gets the area value for this Hub.
     * 
     * @return area
     */
    public int getArea() {
        return area;
    }


    /**
     * Sets the area value for this Hub.
     * 
     * @param area
     */
    public void setArea(int area) {
        this.area = area;
    }


    /**
     * Gets the hub_average_mark value for this Hub.
     * 
     * @return hub_average_mark
     */
    public double getHub_average_mark() {
        return hub_average_mark;
    }


    /**
     * Sets the hub_average_mark value for this Hub.
     * 
     * @param hub_average_mark
     */
    public void setHub_average_mark(double hub_average_mark) {
        this.hub_average_mark = hub_average_mark;
    }


    /**
     * Gets the hub_votes value for this Hub.
     * 
     * @return hub_votes
     */
    public int getHub_votes() {
        return hub_votes;
    }


    /**
     * Sets the hub_votes value for this Hub.
     * 
     * @param hub_votes
     */
    public void setHub_votes(int hub_votes) {
        this.hub_votes = hub_votes;
    }


    /**
     * Gets the lng value for this Hub.
     * 
     * @return lng
     */
    public java.lang.String getLng() {
        return lng;
    }


    /**
     * Sets the lng value for this Hub.
     * 
     * @param lng
     */
    public void setLng(java.lang.String lng) {
        this.lng = lng;
    }


    /**
     * Gets the category value for this Hub.
     * 
     * @return category
     */
    public int getCategory() {
        return category;
    }


    /**
     * Sets the category value for this Hub.
     * 
     * @param category
     */
    public void setCategory(int category) {
        this.category = category;
    }


    /**
     * Gets the address value for this Hub.
     * 
     * @return address
     */
    public java.lang.String getAddress() {
        return address;
    }


    /**
     * Sets the address value for this Hub.
     * 
     * @param address
     */
    public void setAddress(java.lang.String address) {
        this.address = address;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof Hub)) return false;
        Hub other = (Hub) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            this.hub_id == other.getHub_id() &&
            this.user_id == other.getUser_id() &&
            ((this.name==null && other.getName()==null) || 
             (this.name!=null &&
              this.name.equals(other.getName()))) &&
            this.area == other.getArea() &&
            this.hub_average_mark == other.getHub_average_mark() &&
            this.hub_votes == other.getHub_votes() &&
            ((this.lng==null && other.getLng()==null) || 
             (this.lng!=null &&
              this.lng.equals(other.getLng()))) &&
            this.category == other.getCategory() &&
            ((this.address==null && other.getAddress()==null) || 
             (this.address!=null &&
              this.address.equals(other.getAddress())));
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
        _hashCode += getHub_id();
        _hashCode += getUser_id();
        if (getName() != null) {
            _hashCode += getName().hashCode();
        }
        _hashCode += getArea();
        _hashCode += new Double(getHub_average_mark()).hashCode();
        _hashCode += getHub_votes();
        if (getLng() != null) {
            _hashCode += getLng().hashCode();
        }
        _hashCode += getCategory();
        if (getAddress() != null) {
            _hashCode += getAddress().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(Hub.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Hub"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("hub_id");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Hub_id"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("user_id");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "User_id"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("name");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Name"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("area");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Area"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("hub_average_mark");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Hub_average_mark"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "double"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("hub_votes");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Hub_votes"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("lng");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "lng"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("category");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Category"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("address");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Address"));
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

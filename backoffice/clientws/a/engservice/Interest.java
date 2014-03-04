/**
 * Interest.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package net.i2cat.csade.life2.backoffice.clientws.a.engservice;

public class Interest  implements java.io.Serializable {
    private java.lang.String interest_id;

    private java.lang.String interest_name;

    private java.lang.String user_id;

    private long distance;

    private java.lang.String lng;

    public Interest() {
    }

    public Interest(
           java.lang.String interest_id,
           java.lang.String interest_name,
           java.lang.String user_id,
           long distance,
           java.lang.String lng) {
           this.interest_id = interest_id;
           this.interest_name = interest_name;
           this.user_id = user_id;
           this.distance = distance;
           this.lng = lng;
    }


    /**
     * Gets the interest_id value for this Interest.
     * 
     * @return interest_id
     */
    public java.lang.String getInterest_id() {
        return interest_id;
    }


    /**
     * Sets the interest_id value for this Interest.
     * 
     * @param interest_id
     */
    public void setInterest_id(java.lang.String interest_id) {
        this.interest_id = interest_id;
    }


    /**
     * Gets the interest_name value for this Interest.
     * 
     * @return interest_name
     */
    public java.lang.String getInterest_name() {
        return interest_name;
    }


    /**
     * Sets the interest_name value for this Interest.
     * 
     * @param interest_name
     */
    public void setInterest_name(java.lang.String interest_name) {
        this.interest_name = interest_name;
    }


    /**
     * Gets the user_id value for this Interest.
     * 
     * @return user_id
     */
    public java.lang.String getUser_id() {
        return user_id;
    }


    /**
     * Sets the user_id value for this Interest.
     * 
     * @param user_id
     */
    public void setUser_id(java.lang.String user_id) {
        this.user_id = user_id;
    }


    /**
     * Gets the distance value for this Interest.
     * 
     * @return distance
     */
    public long getDistance() {
        return distance;
    }


    /**
     * Sets the distance value for this Interest.
     * 
     * @param distance
     */
    public void setDistance(long distance) {
        this.distance = distance;
    }


    /**
     * Gets the lng value for this Interest.
     * 
     * @return lng
     */
    public java.lang.String getLng() {
        return lng;
    }


    /**
     * Sets the lng value for this Interest.
     * 
     * @param lng
     */
    public void setLng(java.lang.String lng) {
        this.lng = lng;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof Interest)) return false;
        Interest other = (Interest) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.interest_id==null && other.getInterest_id()==null) || 
             (this.interest_id!=null &&
              this.interest_id.equals(other.getInterest_id()))) &&
            ((this.interest_name==null && other.getInterest_name()==null) || 
             (this.interest_name!=null &&
              this.interest_name.equals(other.getInterest_name()))) &&
            ((this.user_id==null && other.getUser_id()==null) || 
             (this.user_id!=null &&
              this.user_id.equals(other.getUser_id()))) &&
            this.distance == other.getDistance() &&
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
        if (getInterest_id() != null) {
            _hashCode += getInterest_id().hashCode();
        }
        if (getInterest_name() != null) {
            _hashCode += getInterest_name().hashCode();
        }
        if (getUser_id() != null) {
            _hashCode += getUser_id().hashCode();
        }
        _hashCode += new Long(getDistance()).hashCode();
        if (getLng() != null) {
            _hashCode += getLng().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(Interest.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Interest"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("interest_id");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "interest_id"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("interest_name");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "interest_name"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("user_id");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "user_id"));
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

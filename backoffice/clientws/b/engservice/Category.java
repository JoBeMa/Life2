/**
 * Category.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package net.i2cat.csade.life2.backoffice.clientws.b.engservice;

public class Category  implements java.io.Serializable {
    private java.lang.String category_id;

    private java.lang.String category_name;

    private java.lang.String category_desc;

    private int status;

    private java.lang.String lng;

    public Category() {
    }

    public Category(
           java.lang.String category_id,
           java.lang.String category_name,
           java.lang.String category_desc,
           int status,
           java.lang.String lng) {
           this.category_id = category_id;
           this.category_name = category_name;
           this.category_desc = category_desc;
           this.status = status;
           this.lng = lng;
    }


    /**
     * Gets the category_id value for this Category.
     * 
     * @return category_id
     */
    public java.lang.String getCategory_id() {
        return category_id;
    }


    /**
     * Sets the category_id value for this Category.
     * 
     * @param category_id
     */
    public void setCategory_id(java.lang.String category_id) {
        this.category_id = category_id;
    }


    /**
     * Gets the category_name value for this Category.
     * 
     * @return category_name
     */
    public java.lang.String getCategory_name() {
        return category_name;
    }


    /**
     * Sets the category_name value for this Category.
     * 
     * @param category_name
     */
    public void setCategory_name(java.lang.String category_name) {
        this.category_name = category_name;
    }


    /**
     * Gets the category_desc value for this Category.
     * 
     * @return category_desc
     */
    public java.lang.String getCategory_desc() {
        return category_desc;
    }


    /**
     * Sets the category_desc value for this Category.
     * 
     * @param category_desc
     */
    public void setCategory_desc(java.lang.String category_desc) {
        this.category_desc = category_desc;
    }


    /**
     * Gets the status value for this Category.
     * 
     * @return status
     */
    public int getStatus() {
        return status;
    }


    /**
     * Sets the status value for this Category.
     * 
     * @param status
     */
    public void setStatus(int status) {
        this.status = status;
    }


    /**
     * Gets the lng value for this Category.
     * 
     * @return lng
     */
    public java.lang.String getLng() {
        return lng;
    }


    /**
     * Sets the lng value for this Category.
     * 
     * @param lng
     */
    public void setLng(java.lang.String lng) {
        this.lng = lng;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof Category)) return false;
        Category other = (Category) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.category_id==null && other.getCategory_id()==null) || 
             (this.category_id!=null &&
              this.category_id.equals(other.getCategory_id()))) &&
            ((this.category_name==null && other.getCategory_name()==null) || 
             (this.category_name!=null &&
              this.category_name.equals(other.getCategory_name()))) &&
            ((this.category_desc==null && other.getCategory_desc()==null) || 
             (this.category_desc!=null &&
              this.category_desc.equals(other.getCategory_desc()))) &&
            this.status == other.getStatus() &&
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
        if (getCategory_id() != null) {
            _hashCode += getCategory_id().hashCode();
        }
        if (getCategory_name() != null) {
            _hashCode += getCategory_name().hashCode();
        }
        if (getCategory_desc() != null) {
            _hashCode += getCategory_desc().hashCode();
        }
        _hashCode += getStatus();
        if (getLng() != null) {
            _hashCode += getLng().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(Category.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Category"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("category_id");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "category_id"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("category_name");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "category_name"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("category_desc");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "category_desc"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("status");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "status"));
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

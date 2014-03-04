/**
 * Skill.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package net.i2cat.csade.life2.backoffice.clientws.b.engservice;

public class Skill  implements java.io.Serializable {
    private java.lang.String skill_id;

    private java.lang.String skill_name;

    private java.lang.String promoter_id;

    private long distance;

    private java.lang.String lng;

    public Skill() {
    }

    public Skill(
           java.lang.String skill_id,
           java.lang.String skill_name,
           java.lang.String promoter_id,
           long distance,
           java.lang.String lng) {
           this.skill_id = skill_id;
           this.skill_name = skill_name;
           this.promoter_id = promoter_id;
           this.distance = distance;
           this.lng = lng;
    }


    /**
     * Gets the skill_id value for this Skill.
     * 
     * @return skill_id
     */
    public java.lang.String getSkill_id() {
        return skill_id;
    }


    /**
     * Sets the skill_id value for this Skill.
     * 
     * @param skill_id
     */
    public void setSkill_id(java.lang.String skill_id) {
        this.skill_id = skill_id;
    }


    /**
     * Gets the skill_name value for this Skill.
     * 
     * @return skill_name
     */
    public java.lang.String getSkill_name() {
        return skill_name;
    }


    /**
     * Sets the skill_name value for this Skill.
     * 
     * @param skill_name
     */
    public void setSkill_name(java.lang.String skill_name) {
        this.skill_name = skill_name;
    }


    /**
     * Gets the promoter_id value for this Skill.
     * 
     * @return promoter_id
     */
    public java.lang.String getPromoter_id() {
        return promoter_id;
    }


    /**
     * Sets the promoter_id value for this Skill.
     * 
     * @param promoter_id
     */
    public void setPromoter_id(java.lang.String promoter_id) {
        this.promoter_id = promoter_id;
    }


    /**
     * Gets the distance value for this Skill.
     * 
     * @return distance
     */
    public long getDistance() {
        return distance;
    }


    /**
     * Sets the distance value for this Skill.
     * 
     * @param distance
     */
    public void setDistance(long distance) {
        this.distance = distance;
    }


    /**
     * Gets the lng value for this Skill.
     * 
     * @return lng
     */
    public java.lang.String getLng() {
        return lng;
    }


    /**
     * Sets the lng value for this Skill.
     * 
     * @param lng
     */
    public void setLng(java.lang.String lng) {
        this.lng = lng;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof Skill)) return false;
        Skill other = (Skill) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.skill_id==null && other.getSkill_id()==null) || 
             (this.skill_id!=null &&
              this.skill_id.equals(other.getSkill_id()))) &&
            ((this.skill_name==null && other.getSkill_name()==null) || 
             (this.skill_name!=null &&
              this.skill_name.equals(other.getSkill_name()))) &&
            ((this.promoter_id==null && other.getPromoter_id()==null) || 
             (this.promoter_id!=null &&
              this.promoter_id.equals(other.getPromoter_id()))) &&
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
        if (getSkill_id() != null) {
            _hashCode += getSkill_id().hashCode();
        }
        if (getSkill_name() != null) {
            _hashCode += getSkill_name().hashCode();
        }
        if (getPromoter_id() != null) {
            _hashCode += getPromoter_id().hashCode();
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
        new org.apache.axis.description.TypeDesc(Skill.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Skill"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("skill_id");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "skill_id"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("skill_name");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "skill_name"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("promoter_id");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "promoter_id"));
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

/**
 * Offer.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package net.i2cat.csade.life2.backoffice.clientws.b.engservice;

public class Offer  implements java.io.Serializable {
    private int offer_id;

    private int offer_type;

    private java.lang.String category;

    private java.lang.String promoter_id;

    private java.lang.String short_Description;

    private java.lang.String detailed_info;

    private java.lang.String when_offer;

    private java.lang.String where_offer;

    private java.util.Calendar deadline;

    private double offer_average_mark;

    private int offer_votes;

    private long distance;

    private java.lang.String lng;

    private int request_id;

    private java.lang.String candidates;

    private int contactType;

    private java.util.Calendar submissionDate;

    private java.lang.String promoterName;

    public Offer() {
    }

    public Offer(
           int offer_id,
           int offer_type,
           java.lang.String category,
           java.lang.String promoter_id,
           java.lang.String short_Description,
           java.lang.String detailed_info,
           java.lang.String when_offer,
           java.lang.String where_offer,
           java.util.Calendar deadline,
           double offer_average_mark,
           int offer_votes,
           long distance,
           java.lang.String lng,
           int request_id,
           java.lang.String candidates,
           int contactType,
           java.util.Calendar submissionDate,
           java.lang.String promoterName) {
           this.offer_id = offer_id;
           this.offer_type = offer_type;
           this.category = category;
           this.promoter_id = promoter_id;
           this.short_Description = short_Description;
           this.detailed_info = detailed_info;
           this.when_offer = when_offer;
           this.where_offer = where_offer;
           this.deadline = deadline;
           this.offer_average_mark = offer_average_mark;
           this.offer_votes = offer_votes;
           this.distance = distance;
           this.lng = lng;
           this.request_id = request_id;
           this.candidates = candidates;
           this.contactType = contactType;
           this.submissionDate = submissionDate;
           this.promoterName = promoterName;
    }


    /**
     * Gets the offer_id value for this Offer.
     * 
     * @return offer_id
     */
    public int getOffer_id() {
        return offer_id;
    }


    /**
     * Sets the offer_id value for this Offer.
     * 
     * @param offer_id
     */
    public void setOffer_id(int offer_id) {
        this.offer_id = offer_id;
    }


    /**
     * Gets the offer_type value for this Offer.
     * 
     * @return offer_type
     */
    public int getOffer_type() {
        return offer_type;
    }


    /**
     * Sets the offer_type value for this Offer.
     * 
     * @param offer_type
     */
    public void setOffer_type(int offer_type) {
        this.offer_type = offer_type;
    }


    /**
     * Gets the category value for this Offer.
     * 
     * @return category
     */
    public java.lang.String getCategory() {
        return category;
    }


    /**
     * Sets the category value for this Offer.
     * 
     * @param category
     */
    public void setCategory(java.lang.String category) {
        this.category = category;
    }


    /**
     * Gets the promoter_id value for this Offer.
     * 
     * @return promoter_id
     */
    public java.lang.String getPromoter_id() {
        return promoter_id;
    }


    /**
     * Sets the promoter_id value for this Offer.
     * 
     * @param promoter_id
     */
    public void setPromoter_id(java.lang.String promoter_id) {
        this.promoter_id = promoter_id;
    }


    /**
     * Gets the short_Description value for this Offer.
     * 
     * @return short_Description
     */
    public java.lang.String getShort_Description() {
        return short_Description;
    }


    /**
     * Sets the short_Description value for this Offer.
     * 
     * @param short_Description
     */
    public void setShort_Description(java.lang.String short_Description) {
        this.short_Description = short_Description;
    }


    /**
     * Gets the detailed_info value for this Offer.
     * 
     * @return detailed_info
     */
    public java.lang.String getDetailed_info() {
        return detailed_info;
    }


    /**
     * Sets the detailed_info value for this Offer.
     * 
     * @param detailed_info
     */
    public void setDetailed_info(java.lang.String detailed_info) {
        this.detailed_info = detailed_info;
    }


    /**
     * Gets the when_offer value for this Offer.
     * 
     * @return when_offer
     */
    public java.lang.String getWhen_offer() {
        return when_offer;
    }


    /**
     * Sets the when_offer value for this Offer.
     * 
     * @param when_offer
     */
    public void setWhen_offer(java.lang.String when_offer) {
        this.when_offer = when_offer;
    }


    /**
     * Gets the where_offer value for this Offer.
     * 
     * @return where_offer
     */
    public java.lang.String getWhere_offer() {
        return where_offer;
    }


    /**
     * Sets the where_offer value for this Offer.
     * 
     * @param where_offer
     */
    public void setWhere_offer(java.lang.String where_offer) {
        this.where_offer = where_offer;
    }


    /**
     * Gets the deadline value for this Offer.
     * 
     * @return deadline
     */
    public java.util.Calendar getDeadline() {
        return deadline;
    }


    /**
     * Sets the deadline value for this Offer.
     * 
     * @param deadline
     */
    public void setDeadline(java.util.Calendar deadline) {
        this.deadline = deadline;
    }


    /**
     * Gets the offer_average_mark value for this Offer.
     * 
     * @return offer_average_mark
     */
    public double getOffer_average_mark() {
        return offer_average_mark;
    }


    /**
     * Sets the offer_average_mark value for this Offer.
     * 
     * @param offer_average_mark
     */
    public void setOffer_average_mark(double offer_average_mark) {
        this.offer_average_mark = offer_average_mark;
    }


    /**
     * Gets the offer_votes value for this Offer.
     * 
     * @return offer_votes
     */
    public int getOffer_votes() {
        return offer_votes;
    }


    /**
     * Sets the offer_votes value for this Offer.
     * 
     * @param offer_votes
     */
    public void setOffer_votes(int offer_votes) {
        this.offer_votes = offer_votes;
    }


    /**
     * Gets the distance value for this Offer.
     * 
     * @return distance
     */
    public long getDistance() {
        return distance;
    }


    /**
     * Sets the distance value for this Offer.
     * 
     * @param distance
     */
    public void setDistance(long distance) {
        this.distance = distance;
    }


    /**
     * Gets the lng value for this Offer.
     * 
     * @return lng
     */
    public java.lang.String getLng() {
        return lng;
    }


    /**
     * Sets the lng value for this Offer.
     * 
     * @param lng
     */
    public void setLng(java.lang.String lng) {
        this.lng = lng;
    }


    /**
     * Gets the request_id value for this Offer.
     * 
     * @return request_id
     */
    public int getRequest_id() {
        return request_id;
    }


    /**
     * Sets the request_id value for this Offer.
     * 
     * @param request_id
     */
    public void setRequest_id(int request_id) {
        this.request_id = request_id;
    }


    /**
     * Gets the candidates value for this Offer.
     * 
     * @return candidates
     */
    public java.lang.String getCandidates() {
        return candidates;
    }


    /**
     * Sets the candidates value for this Offer.
     * 
     * @param candidates
     */
    public void setCandidates(java.lang.String candidates) {
        this.candidates = candidates;
    }


    /**
     * Gets the contactType value for this Offer.
     * 
     * @return contactType
     */
    public int getContactType() {
        return contactType;
    }


    /**
     * Sets the contactType value for this Offer.
     * 
     * @param contactType
     */
    public void setContactType(int contactType) {
        this.contactType = contactType;
    }


    /**
     * Gets the submissionDate value for this Offer.
     * 
     * @return submissionDate
     */
    public java.util.Calendar getSubmissionDate() {
        return submissionDate;
    }


    /**
     * Sets the submissionDate value for this Offer.
     * 
     * @param submissionDate
     */
    public void setSubmissionDate(java.util.Calendar submissionDate) {
        this.submissionDate = submissionDate;
    }


    /**
     * Gets the promoterName value for this Offer.
     * 
     * @return promoterName
     */
    public java.lang.String getPromoterName() {
        return promoterName;
    }


    /**
     * Sets the promoterName value for this Offer.
     * 
     * @param promoterName
     */
    public void setPromoterName(java.lang.String promoterName) {
        this.promoterName = promoterName;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof Offer)) return false;
        Offer other = (Offer) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            this.offer_id == other.getOffer_id() &&
            this.offer_type == other.getOffer_type() &&
            ((this.category==null && other.getCategory()==null) || 
             (this.category!=null &&
              this.category.equals(other.getCategory()))) &&
            ((this.promoter_id==null && other.getPromoter_id()==null) || 
             (this.promoter_id!=null &&
              this.promoter_id.equals(other.getPromoter_id()))) &&
            ((this.short_Description==null && other.getShort_Description()==null) || 
             (this.short_Description!=null &&
              this.short_Description.equals(other.getShort_Description()))) &&
            ((this.detailed_info==null && other.getDetailed_info()==null) || 
             (this.detailed_info!=null &&
              this.detailed_info.equals(other.getDetailed_info()))) &&
            ((this.when_offer==null && other.getWhen_offer()==null) || 
             (this.when_offer!=null &&
              this.when_offer.equals(other.getWhen_offer()))) &&
            ((this.where_offer==null && other.getWhere_offer()==null) || 
             (this.where_offer!=null &&
              this.where_offer.equals(other.getWhere_offer()))) &&
            ((this.deadline==null && other.getDeadline()==null) || 
             (this.deadline!=null &&
              this.deadline.equals(other.getDeadline()))) &&
            this.offer_average_mark == other.getOffer_average_mark() &&
            this.offer_votes == other.getOffer_votes() &&
            this.distance == other.getDistance() &&
            ((this.lng==null && other.getLng()==null) || 
             (this.lng!=null &&
              this.lng.equals(other.getLng()))) &&
            this.request_id == other.getRequest_id() &&
            ((this.candidates==null && other.getCandidates()==null) || 
             (this.candidates!=null &&
              this.candidates.equals(other.getCandidates()))) &&
            this.contactType == other.getContactType() &&
            ((this.submissionDate==null && other.getSubmissionDate()==null) || 
             (this.submissionDate!=null &&
              this.submissionDate.equals(other.getSubmissionDate()))) &&
            ((this.promoterName==null && other.getPromoterName()==null) || 
             (this.promoterName!=null &&
              this.promoterName.equals(other.getPromoterName())));
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
        _hashCode += getOffer_id();
        _hashCode += getOffer_type();
        if (getCategory() != null) {
            _hashCode += getCategory().hashCode();
        }
        if (getPromoter_id() != null) {
            _hashCode += getPromoter_id().hashCode();
        }
        if (getShort_Description() != null) {
            _hashCode += getShort_Description().hashCode();
        }
        if (getDetailed_info() != null) {
            _hashCode += getDetailed_info().hashCode();
        }
        if (getWhen_offer() != null) {
            _hashCode += getWhen_offer().hashCode();
        }
        if (getWhere_offer() != null) {
            _hashCode += getWhere_offer().hashCode();
        }
        if (getDeadline() != null) {
            _hashCode += getDeadline().hashCode();
        }
        _hashCode += new Double(getOffer_average_mark()).hashCode();
        _hashCode += getOffer_votes();
        _hashCode += new Long(getDistance()).hashCode();
        if (getLng() != null) {
            _hashCode += getLng().hashCode();
        }
        _hashCode += getRequest_id();
        if (getCandidates() != null) {
            _hashCode += getCandidates().hashCode();
        }
        _hashCode += getContactType();
        if (getSubmissionDate() != null) {
            _hashCode += getSubmissionDate().hashCode();
        }
        if (getPromoterName() != null) {
            _hashCode += getPromoterName().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(Offer.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Offer"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("offer_id");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Offer_id"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("offer_type");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Offer_type"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("category");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Category"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("promoter_id");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Promoter_id"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("short_Description");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Short_Description"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("detailed_info");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Detailed_info"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("when_offer");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "When_offer"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("where_offer");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Where_offer"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("deadline");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Deadline"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "dateTime"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("offer_average_mark");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Offer_average_mark"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "double"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("offer_votes");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Offer_votes"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
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
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("request_id");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Request_id"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("candidates");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Candidates"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("contactType");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "ContactType"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("submissionDate");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "SubmissionDate"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "dateTime"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("promoterName");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "PromoterName"));
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

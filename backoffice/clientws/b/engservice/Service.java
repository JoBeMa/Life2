/**
 * Service.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package net.i2cat.csade.life2.backoffice.clientws.b.engservice;

public class Service  implements java.io.Serializable {
    private int id;

    private java.lang.String category;

    private java.lang.String promoter_id;

    private java.lang.String short_Description;

    private java.lang.String detailed_info;

    private java.lang.String when_c;

    private java.lang.String where_c;

    private java.util.Calendar deadline;

    private double average_mark;

    private int votes;

    private long distance;

    private java.lang.String lng;

    private java.lang.String candidates;

    private int contactType;

    private java.util.Calendar submissionDate;

    public Service() {
    }

    public Service(
           int id,
           java.lang.String category,
           java.lang.String promoter_id,
           java.lang.String short_Description,
           java.lang.String detailed_info,
           java.lang.String when_c,
           java.lang.String where_c,
           java.util.Calendar deadline,
           double average_mark,
           int votes,
           long distance,
           java.lang.String lng,
           java.lang.String candidates,
           int contactType,
           java.util.Calendar submissionDate) {
           this.id = id;
           this.category = category;
           this.promoter_id = promoter_id;
           this.short_Description = short_Description;
           this.detailed_info = detailed_info;
           this.when_c = when_c;
           this.where_c = where_c;
           this.deadline = deadline;
           this.average_mark = average_mark;
           this.votes = votes;
           this.distance = distance;
           this.lng = lng;
           this.candidates = candidates;
           this.contactType = contactType;
           this.submissionDate = submissionDate;
    }


    /**
     * Gets the id value for this Service.
     * 
     * @return id
     */
    public int getId() {
        return id;
    }


    /**
     * Sets the id value for this Service.
     * 
     * @param id
     */
    public void setId(int id) {
        this.id = id;
    }


    /**
     * Gets the category value for this Service.
     * 
     * @return category
     */
    public java.lang.String getCategory() {
        return category;
    }


    /**
     * Sets the category value for this Service.
     * 
     * @param category
     */
    public void setCategory(java.lang.String category) {
        this.category = category;
    }


    /**
     * Gets the promoter_id value for this Service.
     * 
     * @return promoter_id
     */
    public java.lang.String getPromoter_id() {
        return promoter_id;
    }


    /**
     * Sets the promoter_id value for this Service.
     * 
     * @param promoter_id
     */
    public void setPromoter_id(java.lang.String promoter_id) {
        this.promoter_id = promoter_id;
    }


    /**
     * Gets the short_Description value for this Service.
     * 
     * @return short_Description
     */
    public java.lang.String getShort_Description() {
        return short_Description;
    }


    /**
     * Sets the short_Description value for this Service.
     * 
     * @param short_Description
     */
    public void setShort_Description(java.lang.String short_Description) {
        this.short_Description = short_Description;
    }


    /**
     * Gets the detailed_info value for this Service.
     * 
     * @return detailed_info
     */
    public java.lang.String getDetailed_info() {
        return detailed_info;
    }


    /**
     * Sets the detailed_info value for this Service.
     * 
     * @param detailed_info
     */
    public void setDetailed_info(java.lang.String detailed_info) {
        this.detailed_info = detailed_info;
    }


    /**
     * Gets the when_c value for this Service.
     * 
     * @return when_c
     */
    public java.lang.String getWhen_c() {
        return when_c;
    }


    /**
     * Sets the when_c value for this Service.
     * 
     * @param when_c
     */
    public void setWhen_c(java.lang.String when_c) {
        this.when_c = when_c;
    }


    /**
     * Gets the where_c value for this Service.
     * 
     * @return where_c
     */
    public java.lang.String getWhere_c() {
        return where_c;
    }


    /**
     * Sets the where_c value for this Service.
     * 
     * @param where_c
     */
    public void setWhere_c(java.lang.String where_c) {
        this.where_c = where_c;
    }


    /**
     * Gets the deadline value for this Service.
     * 
     * @return deadline
     */
    public java.util.Calendar getDeadline() {
        return deadline;
    }


    /**
     * Sets the deadline value for this Service.
     * 
     * @param deadline
     */
    public void setDeadline(java.util.Calendar deadline) {
        this.deadline = deadline;
    }


    /**
     * Gets the average_mark value for this Service.
     * 
     * @return average_mark
     */
    public double getAverage_mark() {
        return average_mark;
    }


    /**
     * Sets the average_mark value for this Service.
     * 
     * @param average_mark
     */
    public void setAverage_mark(double average_mark) {
        this.average_mark = average_mark;
    }


    /**
     * Gets the votes value for this Service.
     * 
     * @return votes
     */
    public int getVotes() {
        return votes;
    }


    /**
     * Sets the votes value for this Service.
     * 
     * @param votes
     */
    public void setVotes(int votes) {
        this.votes = votes;
    }


    /**
     * Gets the distance value for this Service.
     * 
     * @return distance
     */
    public long getDistance() {
        return distance;
    }


    /**
     * Sets the distance value for this Service.
     * 
     * @param distance
     */
    public void setDistance(long distance) {
        this.distance = distance;
    }


    /**
     * Gets the lng value for this Service.
     * 
     * @return lng
     */
    public java.lang.String getLng() {
        return lng;
    }


    /**
     * Sets the lng value for this Service.
     * 
     * @param lng
     */
    public void setLng(java.lang.String lng) {
        this.lng = lng;
    }


    /**
     * Gets the candidates value for this Service.
     * 
     * @return candidates
     */
    public java.lang.String getCandidates() {
        return candidates;
    }


    /**
     * Sets the candidates value for this Service.
     * 
     * @param candidates
     */
    public void setCandidates(java.lang.String candidates) {
        this.candidates = candidates;
    }


    /**
     * Gets the contactType value for this Service.
     * 
     * @return contactType
     */
    public int getContactType() {
        return contactType;
    }


    /**
     * Sets the contactType value for this Service.
     * 
     * @param contactType
     */
    public void setContactType(int contactType) {
        this.contactType = contactType;
    }


    /**
     * Gets the submissionDate value for this Service.
     * 
     * @return submissionDate
     */
    public java.util.Calendar getSubmissionDate() {
        return submissionDate;
    }


    /**
     * Sets the submissionDate value for this Service.
     * 
     * @param submissionDate
     */
    public void setSubmissionDate(java.util.Calendar submissionDate) {
        this.submissionDate = submissionDate;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof Service)) return false;
        Service other = (Service) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            this.id == other.getId() &&
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
            ((this.when_c==null && other.getWhen_c()==null) || 
             (this.when_c!=null &&
              this.when_c.equals(other.getWhen_c()))) &&
            ((this.where_c==null && other.getWhere_c()==null) || 
             (this.where_c!=null &&
              this.where_c.equals(other.getWhere_c()))) &&
            ((this.deadline==null && other.getDeadline()==null) || 
             (this.deadline!=null &&
              this.deadline.equals(other.getDeadline()))) &&
            this.average_mark == other.getAverage_mark() &&
            this.votes == other.getVotes() &&
            this.distance == other.getDistance() &&
            ((this.lng==null && other.getLng()==null) || 
             (this.lng!=null &&
              this.lng.equals(other.getLng()))) &&
            ((this.candidates==null && other.getCandidates()==null) || 
             (this.candidates!=null &&
              this.candidates.equals(other.getCandidates()))) &&
            this.contactType == other.getContactType() &&
            ((this.submissionDate==null && other.getSubmissionDate()==null) || 
             (this.submissionDate!=null &&
              this.submissionDate.equals(other.getSubmissionDate())));
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
        _hashCode += getId();
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
        if (getWhen_c() != null) {
            _hashCode += getWhen_c().hashCode();
        }
        if (getWhere_c() != null) {
            _hashCode += getWhere_c().hashCode();
        }
        if (getDeadline() != null) {
            _hashCode += getDeadline().hashCode();
        }
        _hashCode += new Double(getAverage_mark()).hashCode();
        _hashCode += getVotes();
        _hashCode += new Long(getDistance()).hashCode();
        if (getLng() != null) {
            _hashCode += getLng().hashCode();
        }
        if (getCandidates() != null) {
            _hashCode += getCandidates().hashCode();
        }
        _hashCode += getContactType();
        if (getSubmissionDate() != null) {
            _hashCode += getSubmissionDate().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(Service.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Service"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("id");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Id"));
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
        elemField.setFieldName("when_c");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "When_c"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("where_c");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Where_c"));
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
        elemField.setFieldName("average_mark");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Average_mark"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "double"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("votes");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Votes"));
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

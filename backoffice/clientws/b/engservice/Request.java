/**
 * Request.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package net.i2cat.csade.life2.backoffice.clientws.b.engservice;

public class Request  implements java.io.Serializable {
    private int request_id;

    private int requester_id;

    private java.lang.String request_type;

    private java.lang.String category_id;

    private java.lang.String short_description;

    private java.lang.String description;

    private java.lang.String when_request;

    private java.lang.String where_request;

    private java.lang.String filtering_preferences;

    private int status;

    private java.util.Calendar deadline;

    private java.lang.String candidates;

    private long distance;

    private java.lang.String lng;

    private int contactType;

    private java.util.Calendar submissionDate;

    private java.lang.String promoterName;

    public Request() {
    }

    public Request(
           int request_id,
           int requester_id,
           java.lang.String request_type,
           java.lang.String category_id,
           java.lang.String short_description,
           java.lang.String description,
           java.lang.String when_request,
           java.lang.String where_request,
           java.lang.String filtering_preferences,
           int status,
           java.util.Calendar deadline,
           java.lang.String candidates,
           long distance,
           java.lang.String lng,
           int contactType,
           java.util.Calendar submissionDate,
           java.lang.String promoterName) {
           this.request_id = request_id;
           this.requester_id = requester_id;
           this.request_type = request_type;
           this.category_id = category_id;
           this.short_description = short_description;
           this.description = description;
           this.when_request = when_request;
           this.where_request = where_request;
           this.filtering_preferences = filtering_preferences;
           this.status = status;
           this.deadline = deadline;
           this.candidates = candidates;
           this.distance = distance;
           this.lng = lng;
           this.contactType = contactType;
           this.submissionDate = submissionDate;
           this.promoterName = promoterName;
    }


    /**
     * Gets the request_id value for this Request.
     * 
     * @return request_id
     */
    public int getRequest_id() {
        return request_id;
    }


    /**
     * Sets the request_id value for this Request.
     * 
     * @param request_id
     */
    public void setRequest_id(int request_id) {
        this.request_id = request_id;
    }


    /**
     * Gets the requester_id value for this Request.
     * 
     * @return requester_id
     */
    public int getRequester_id() {
        return requester_id;
    }


    /**
     * Sets the requester_id value for this Request.
     * 
     * @param requester_id
     */
    public void setRequester_id(int requester_id) {
        this.requester_id = requester_id;
    }


    /**
     * Gets the request_type value for this Request.
     * 
     * @return request_type
     */
    public java.lang.String getRequest_type() {
        return request_type;
    }


    /**
     * Sets the request_type value for this Request.
     * 
     * @param request_type
     */
    public void setRequest_type(java.lang.String request_type) {
        this.request_type = request_type;
    }


    /**
     * Gets the category_id value for this Request.
     * 
     * @return category_id
     */
    public java.lang.String getCategory_id() {
        return category_id;
    }


    /**
     * Sets the category_id value for this Request.
     * 
     * @param category_id
     */
    public void setCategory_id(java.lang.String category_id) {
        this.category_id = category_id;
    }


    /**
     * Gets the short_description value for this Request.
     * 
     * @return short_description
     */
    public java.lang.String getShort_description() {
        return short_description;
    }


    /**
     * Sets the short_description value for this Request.
     * 
     * @param short_description
     */
    public void setShort_description(java.lang.String short_description) {
        this.short_description = short_description;
    }


    /**
     * Gets the description value for this Request.
     * 
     * @return description
     */
    public java.lang.String getDescription() {
        return description;
    }


    /**
     * Sets the description value for this Request.
     * 
     * @param description
     */
    public void setDescription(java.lang.String description) {
        this.description = description;
    }


    /**
     * Gets the when_request value for this Request.
     * 
     * @return when_request
     */
    public java.lang.String getWhen_request() {
        return when_request;
    }


    /**
     * Sets the when_request value for this Request.
     * 
     * @param when_request
     */
    public void setWhen_request(java.lang.String when_request) {
        this.when_request = when_request;
    }


    /**
     * Gets the where_request value for this Request.
     * 
     * @return where_request
     */
    public java.lang.String getWhere_request() {
        return where_request;
    }


    /**
     * Sets the where_request value for this Request.
     * 
     * @param where_request
     */
    public void setWhere_request(java.lang.String where_request) {
        this.where_request = where_request;
    }


    /**
     * Gets the filtering_preferences value for this Request.
     * 
     * @return filtering_preferences
     */
    public java.lang.String getFiltering_preferences() {
        return filtering_preferences;
    }


    /**
     * Sets the filtering_preferences value for this Request.
     * 
     * @param filtering_preferences
     */
    public void setFiltering_preferences(java.lang.String filtering_preferences) {
        this.filtering_preferences = filtering_preferences;
    }


    /**
     * Gets the status value for this Request.
     * 
     * @return status
     */
    public int getStatus() {
        return status;
    }


    /**
     * Sets the status value for this Request.
     * 
     * @param status
     */
    public void setStatus(int status) {
        this.status = status;
    }


    /**
     * Gets the deadline value for this Request.
     * 
     * @return deadline
     */
    public java.util.Calendar getDeadline() {
        return deadline;
    }


    /**
     * Sets the deadline value for this Request.
     * 
     * @param deadline
     */
    public void setDeadline(java.util.Calendar deadline) {
        this.deadline = deadline;
    }


    /**
     * Gets the candidates value for this Request.
     * 
     * @return candidates
     */
    public java.lang.String getCandidates() {
        return candidates;
    }


    /**
     * Sets the candidates value for this Request.
     * 
     * @param candidates
     */
    public void setCandidates(java.lang.String candidates) {
        this.candidates = candidates;
    }


    /**
     * Gets the distance value for this Request.
     * 
     * @return distance
     */
    public long getDistance() {
        return distance;
    }


    /**
     * Sets the distance value for this Request.
     * 
     * @param distance
     */
    public void setDistance(long distance) {
        this.distance = distance;
    }


    /**
     * Gets the lng value for this Request.
     * 
     * @return lng
     */
    public java.lang.String getLng() {
        return lng;
    }


    /**
     * Sets the lng value for this Request.
     * 
     * @param lng
     */
    public void setLng(java.lang.String lng) {
        this.lng = lng;
    }


    /**
     * Gets the contactType value for this Request.
     * 
     * @return contactType
     */
    public int getContactType() {
        return contactType;
    }


    /**
     * Sets the contactType value for this Request.
     * 
     * @param contactType
     */
    public void setContactType(int contactType) {
        this.contactType = contactType;
    }


    /**
     * Gets the submissionDate value for this Request.
     * 
     * @return submissionDate
     */
    public java.util.Calendar getSubmissionDate() {
        return submissionDate;
    }


    /**
     * Sets the submissionDate value for this Request.
     * 
     * @param submissionDate
     */
    public void setSubmissionDate(java.util.Calendar submissionDate) {
        this.submissionDate = submissionDate;
    }


    /**
     * Gets the promoterName value for this Request.
     * 
     * @return promoterName
     */
    public java.lang.String getPromoterName() {
        return promoterName;
    }


    /**
     * Sets the promoterName value for this Request.
     * 
     * @param promoterName
     */
    public void setPromoterName(java.lang.String promoterName) {
        this.promoterName = promoterName;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof Request)) return false;
        Request other = (Request) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            this.request_id == other.getRequest_id() &&
            this.requester_id == other.getRequester_id() &&
            ((this.request_type==null && other.getRequest_type()==null) || 
             (this.request_type!=null &&
              this.request_type.equals(other.getRequest_type()))) &&
            ((this.category_id==null && other.getCategory_id()==null) || 
             (this.category_id!=null &&
              this.category_id.equals(other.getCategory_id()))) &&
            ((this.short_description==null && other.getShort_description()==null) || 
             (this.short_description!=null &&
              this.short_description.equals(other.getShort_description()))) &&
            ((this.description==null && other.getDescription()==null) || 
             (this.description!=null &&
              this.description.equals(other.getDescription()))) &&
            ((this.when_request==null && other.getWhen_request()==null) || 
             (this.when_request!=null &&
              this.when_request.equals(other.getWhen_request()))) &&
            ((this.where_request==null && other.getWhere_request()==null) || 
             (this.where_request!=null &&
              this.where_request.equals(other.getWhere_request()))) &&
            ((this.filtering_preferences==null && other.getFiltering_preferences()==null) || 
             (this.filtering_preferences!=null &&
              this.filtering_preferences.equals(other.getFiltering_preferences()))) &&
            this.status == other.getStatus() &&
            ((this.deadline==null && other.getDeadline()==null) || 
             (this.deadline!=null &&
              this.deadline.equals(other.getDeadline()))) &&
            ((this.candidates==null && other.getCandidates()==null) || 
             (this.candidates!=null &&
              this.candidates.equals(other.getCandidates()))) &&
            this.distance == other.getDistance() &&
            ((this.lng==null && other.getLng()==null) || 
             (this.lng!=null &&
              this.lng.equals(other.getLng()))) &&
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
        _hashCode += getRequest_id();
        _hashCode += getRequester_id();
        if (getRequest_type() != null) {
            _hashCode += getRequest_type().hashCode();
        }
        if (getCategory_id() != null) {
            _hashCode += getCategory_id().hashCode();
        }
        if (getShort_description() != null) {
            _hashCode += getShort_description().hashCode();
        }
        if (getDescription() != null) {
            _hashCode += getDescription().hashCode();
        }
        if (getWhen_request() != null) {
            _hashCode += getWhen_request().hashCode();
        }
        if (getWhere_request() != null) {
            _hashCode += getWhere_request().hashCode();
        }
        if (getFiltering_preferences() != null) {
            _hashCode += getFiltering_preferences().hashCode();
        }
        _hashCode += getStatus();
        if (getDeadline() != null) {
            _hashCode += getDeadline().hashCode();
        }
        if (getCandidates() != null) {
            _hashCode += getCandidates().hashCode();
        }
        _hashCode += new Long(getDistance()).hashCode();
        if (getLng() != null) {
            _hashCode += getLng().hashCode();
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
        new org.apache.axis.description.TypeDesc(Request.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Request"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("request_id");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Request_id"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("requester_id");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Requester_id"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("request_type");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Request_type"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("category_id");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Category_id"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("short_description");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Short_description"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("description");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Description"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("when_request");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "When_request"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("where_request");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Where_request"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("filtering_preferences");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Filtering_preferences"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("status");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Status"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("deadline");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Deadline"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "dateTime"));
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

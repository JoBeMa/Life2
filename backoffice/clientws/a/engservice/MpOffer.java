/**
 * MpOffer.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package net.i2cat.csade.life2.backoffice.clientws.a.engservice;

public class MpOffer  implements java.io.Serializable {
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

    private java.lang.String orgName;

    private java.lang.String title;

    private java.util.Calendar dateOfActivity;

    private java.lang.String address;

    private java.lang.String telephone;

    private java.lang.String mobile;

    private java.lang.String email;

    private java.lang.String url_booking;

    private java.lang.String url_web;

    private java.lang.String url_brochure;

    private java.lang.String price;

    private int subscription;

    private int maxParticipants;

    private java.util.Calendar submissionDate;

    private int views;

    public MpOffer() {
    }

    public MpOffer(
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
           java.lang.String orgName,
           java.lang.String title,
           java.util.Calendar dateOfActivity,
           java.lang.String address,
           java.lang.String telephone,
           java.lang.String mobile,
           java.lang.String email,
           java.lang.String url_booking,
           java.lang.String url_web,
           java.lang.String url_brochure,
           java.lang.String price,
           int subscription,
           int maxParticipants,
           java.util.Calendar submissionDate,
           int views) {
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
           this.orgName = orgName;
           this.title = title;
           this.dateOfActivity = dateOfActivity;
           this.address = address;
           this.telephone = telephone;
           this.mobile = mobile;
           this.email = email;
           this.url_booking = url_booking;
           this.url_web = url_web;
           this.url_brochure = url_brochure;
           this.price = price;
           this.subscription = subscription;
           this.maxParticipants = maxParticipants;
           this.submissionDate = submissionDate;
           this.views = views;
    }


    /**
     * Gets the id value for this MpOffer.
     * 
     * @return id
     */
    public int getId() {
        return id;
    }


    /**
     * Sets the id value for this MpOffer.
     * 
     * @param id
     */
    public void setId(int id) {
        this.id = id;
    }


    /**
     * Gets the category value for this MpOffer.
     * 
     * @return category
     */
    public java.lang.String getCategory() {
        return category;
    }


    /**
     * Sets the category value for this MpOffer.
     * 
     * @param category
     */
    public void setCategory(java.lang.String category) {
        this.category = category;
    }


    /**
     * Gets the promoter_id value for this MpOffer.
     * 
     * @return promoter_id
     */
    public java.lang.String getPromoter_id() {
        return promoter_id;
    }


    /**
     * Sets the promoter_id value for this MpOffer.
     * 
     * @param promoter_id
     */
    public void setPromoter_id(java.lang.String promoter_id) {
        this.promoter_id = promoter_id;
    }


    /**
     * Gets the short_Description value for this MpOffer.
     * 
     * @return short_Description
     */
    public java.lang.String getShort_Description() {
        return short_Description;
    }


    /**
     * Sets the short_Description value for this MpOffer.
     * 
     * @param short_Description
     */
    public void setShort_Description(java.lang.String short_Description) {
        this.short_Description = short_Description;
    }


    /**
     * Gets the detailed_info value for this MpOffer.
     * 
     * @return detailed_info
     */
    public java.lang.String getDetailed_info() {
        return detailed_info;
    }


    /**
     * Sets the detailed_info value for this MpOffer.
     * 
     * @param detailed_info
     */
    public void setDetailed_info(java.lang.String detailed_info) {
        this.detailed_info = detailed_info;
    }


    /**
     * Gets the when_c value for this MpOffer.
     * 
     * @return when_c
     */
    public java.lang.String getWhen_c() {
        return when_c;
    }


    /**
     * Sets the when_c value for this MpOffer.
     * 
     * @param when_c
     */
    public void setWhen_c(java.lang.String when_c) {
        this.when_c = when_c;
    }


    /**
     * Gets the where_c value for this MpOffer.
     * 
     * @return where_c
     */
    public java.lang.String getWhere_c() {
        return where_c;
    }


    /**
     * Sets the where_c value for this MpOffer.
     * 
     * @param where_c
     */
    public void setWhere_c(java.lang.String where_c) {
        this.where_c = where_c;
    }


    /**
     * Gets the deadline value for this MpOffer.
     * 
     * @return deadline
     */
    public java.util.Calendar getDeadline() {
        return deadline;
    }


    /**
     * Sets the deadline value for this MpOffer.
     * 
     * @param deadline
     */
    public void setDeadline(java.util.Calendar deadline) {
        this.deadline = deadline;
    }


    /**
     * Gets the average_mark value for this MpOffer.
     * 
     * @return average_mark
     */
    public double getAverage_mark() {
        return average_mark;
    }


    /**
     * Sets the average_mark value for this MpOffer.
     * 
     * @param average_mark
     */
    public void setAverage_mark(double average_mark) {
        this.average_mark = average_mark;
    }


    /**
     * Gets the votes value for this MpOffer.
     * 
     * @return votes
     */
    public int getVotes() {
        return votes;
    }


    /**
     * Sets the votes value for this MpOffer.
     * 
     * @param votes
     */
    public void setVotes(int votes) {
        this.votes = votes;
    }


    /**
     * Gets the distance value for this MpOffer.
     * 
     * @return distance
     */
    public long getDistance() {
        return distance;
    }


    /**
     * Sets the distance value for this MpOffer.
     * 
     * @param distance
     */
    public void setDistance(long distance) {
        this.distance = distance;
    }


    /**
     * Gets the lng value for this MpOffer.
     * 
     * @return lng
     */
    public java.lang.String getLng() {
        return lng;
    }


    /**
     * Sets the lng value for this MpOffer.
     * 
     * @param lng
     */
    public void setLng(java.lang.String lng) {
        this.lng = lng;
    }


    /**
     * Gets the candidates value for this MpOffer.
     * 
     * @return candidates
     */
    public java.lang.String getCandidates() {
        return candidates;
    }


    /**
     * Sets the candidates value for this MpOffer.
     * 
     * @param candidates
     */
    public void setCandidates(java.lang.String candidates) {
        this.candidates = candidates;
    }


    /**
     * Gets the contactType value for this MpOffer.
     * 
     * @return contactType
     */
    public int getContactType() {
        return contactType;
    }


    /**
     * Sets the contactType value for this MpOffer.
     * 
     * @param contactType
     */
    public void setContactType(int contactType) {
        this.contactType = contactType;
    }


    /**
     * Gets the orgName value for this MpOffer.
     * 
     * @return orgName
     */
    public java.lang.String getOrgName() {
        return orgName;
    }


    /**
     * Sets the orgName value for this MpOffer.
     * 
     * @param orgName
     */
    public void setOrgName(java.lang.String orgName) {
        this.orgName = orgName;
    }


    /**
     * Gets the title value for this MpOffer.
     * 
     * @return title
     */
    public java.lang.String getTitle() {
        return title;
    }


    /**
     * Sets the title value for this MpOffer.
     * 
     * @param title
     */
    public void setTitle(java.lang.String title) {
        this.title = title;
    }


    /**
     * Gets the dateOfActivity value for this MpOffer.
     * 
     * @return dateOfActivity
     */
    public java.util.Calendar getDateOfActivity() {
        return dateOfActivity;
    }


    /**
     * Sets the dateOfActivity value for this MpOffer.
     * 
     * @param dateOfActivity
     */
    public void setDateOfActivity(java.util.Calendar dateOfActivity) {
        this.dateOfActivity = dateOfActivity;
    }


    /**
     * Gets the address value for this MpOffer.
     * 
     * @return address
     */
    public java.lang.String getAddress() {
        return address;
    }


    /**
     * Sets the address value for this MpOffer.
     * 
     * @param address
     */
    public void setAddress(java.lang.String address) {
        this.address = address;
    }


    /**
     * Gets the telephone value for this MpOffer.
     * 
     * @return telephone
     */
    public java.lang.String getTelephone() {
        return telephone;
    }


    /**
     * Sets the telephone value for this MpOffer.
     * 
     * @param telephone
     */
    public void setTelephone(java.lang.String telephone) {
        this.telephone = telephone;
    }


    /**
     * Gets the mobile value for this MpOffer.
     * 
     * @return mobile
     */
    public java.lang.String getMobile() {
        return mobile;
    }


    /**
     * Sets the mobile value for this MpOffer.
     * 
     * @param mobile
     */
    public void setMobile(java.lang.String mobile) {
        this.mobile = mobile;
    }


    /**
     * Gets the email value for this MpOffer.
     * 
     * @return email
     */
    public java.lang.String getEmail() {
        return email;
    }


    /**
     * Sets the email value for this MpOffer.
     * 
     * @param email
     */
    public void setEmail(java.lang.String email) {
        this.email = email;
    }


    /**
     * Gets the url_booking value for this MpOffer.
     * 
     * @return url_booking
     */
    public java.lang.String getUrl_booking() {
        return url_booking;
    }


    /**
     * Sets the url_booking value for this MpOffer.
     * 
     * @param url_booking
     */
    public void setUrl_booking(java.lang.String url_booking) {
        this.url_booking = url_booking;
    }


    /**
     * Gets the url_web value for this MpOffer.
     * 
     * @return url_web
     */
    public java.lang.String getUrl_web() {
        return url_web;
    }


    /**
     * Sets the url_web value for this MpOffer.
     * 
     * @param url_web
     */
    public void setUrl_web(java.lang.String url_web) {
        this.url_web = url_web;
    }


    /**
     * Gets the url_brochure value for this MpOffer.
     * 
     * @return url_brochure
     */
    public java.lang.String getUrl_brochure() {
        return url_brochure;
    }


    /**
     * Sets the url_brochure value for this MpOffer.
     * 
     * @param url_brochure
     */
    public void setUrl_brochure(java.lang.String url_brochure) {
        this.url_brochure = url_brochure;
    }


    /**
     * Gets the price value for this MpOffer.
     * 
     * @return price
     */
    public java.lang.String getPrice() {
        return price;
    }


    /**
     * Sets the price value for this MpOffer.
     * 
     * @param price
     */
    public void setPrice(java.lang.String price) {
        this.price = price;
    }


    /**
     * Gets the subscription value for this MpOffer.
     * 
     * @return subscription
     */
    public int getSubscription() {
        return subscription;
    }


    /**
     * Sets the subscription value for this MpOffer.
     * 
     * @param subscription
     */
    public void setSubscription(int subscription) {
        this.subscription = subscription;
    }


    /**
     * Gets the maxParticipants value for this MpOffer.
     * 
     * @return maxParticipants
     */
    public int getMaxParticipants() {
        return maxParticipants;
    }


    /**
     * Sets the maxParticipants value for this MpOffer.
     * 
     * @param maxParticipants
     */
    public void setMaxParticipants(int maxParticipants) {
        this.maxParticipants = maxParticipants;
    }


    /**
     * Gets the submissionDate value for this MpOffer.
     * 
     * @return submissionDate
     */
    public java.util.Calendar getSubmissionDate() {
        return submissionDate;
    }


    /**
     * Sets the submissionDate value for this MpOffer.
     * 
     * @param submissionDate
     */
    public void setSubmissionDate(java.util.Calendar submissionDate) {
        this.submissionDate = submissionDate;
    }


    /**
     * Gets the views value for this MpOffer.
     * 
     * @return views
     */
    public int getViews() {
        return views;
    }


    /**
     * Sets the views value for this MpOffer.
     * 
     * @param views
     */
    public void setViews(int views) {
        this.views = views;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof MpOffer)) return false;
        MpOffer other = (MpOffer) obj;
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
            ((this.orgName==null && other.getOrgName()==null) || 
             (this.orgName!=null &&
              this.orgName.equals(other.getOrgName()))) &&
            ((this.title==null && other.getTitle()==null) || 
             (this.title!=null &&
              this.title.equals(other.getTitle()))) &&
            ((this.dateOfActivity==null && other.getDateOfActivity()==null) || 
             (this.dateOfActivity!=null &&
              this.dateOfActivity.equals(other.getDateOfActivity()))) &&
            ((this.address==null && other.getAddress()==null) || 
             (this.address!=null &&
              this.address.equals(other.getAddress()))) &&
            ((this.telephone==null && other.getTelephone()==null) || 
             (this.telephone!=null &&
              this.telephone.equals(other.getTelephone()))) &&
            ((this.mobile==null && other.getMobile()==null) || 
             (this.mobile!=null &&
              this.mobile.equals(other.getMobile()))) &&
            ((this.email==null && other.getEmail()==null) || 
             (this.email!=null &&
              this.email.equals(other.getEmail()))) &&
            ((this.url_booking==null && other.getUrl_booking()==null) || 
             (this.url_booking!=null &&
              this.url_booking.equals(other.getUrl_booking()))) &&
            ((this.url_web==null && other.getUrl_web()==null) || 
             (this.url_web!=null &&
              this.url_web.equals(other.getUrl_web()))) &&
            ((this.url_brochure==null && other.getUrl_brochure()==null) || 
             (this.url_brochure!=null &&
              this.url_brochure.equals(other.getUrl_brochure()))) &&
            ((this.price==null && other.getPrice()==null) || 
             (this.price!=null &&
              this.price.equals(other.getPrice()))) &&
            this.subscription == other.getSubscription() &&
            this.maxParticipants == other.getMaxParticipants() &&
            ((this.submissionDate==null && other.getSubmissionDate()==null) || 
             (this.submissionDate!=null &&
              this.submissionDate.equals(other.getSubmissionDate()))) &&
            this.views == other.getViews();
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
        if (getOrgName() != null) {
            _hashCode += getOrgName().hashCode();
        }
        if (getTitle() != null) {
            _hashCode += getTitle().hashCode();
        }
        if (getDateOfActivity() != null) {
            _hashCode += getDateOfActivity().hashCode();
        }
        if (getAddress() != null) {
            _hashCode += getAddress().hashCode();
        }
        if (getTelephone() != null) {
            _hashCode += getTelephone().hashCode();
        }
        if (getMobile() != null) {
            _hashCode += getMobile().hashCode();
        }
        if (getEmail() != null) {
            _hashCode += getEmail().hashCode();
        }
        if (getUrl_booking() != null) {
            _hashCode += getUrl_booking().hashCode();
        }
        if (getUrl_web() != null) {
            _hashCode += getUrl_web().hashCode();
        }
        if (getUrl_brochure() != null) {
            _hashCode += getUrl_brochure().hashCode();
        }
        if (getPrice() != null) {
            _hashCode += getPrice().hashCode();
        }
        _hashCode += getSubscription();
        _hashCode += getMaxParticipants();
        if (getSubmissionDate() != null) {
            _hashCode += getSubmissionDate().hashCode();
        }
        _hashCode += getViews();
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(MpOffer.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "MpOffer"));
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
        elemField.setFieldName("orgName");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "OrgName"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("title");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Title"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("dateOfActivity");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "DateOfActivity"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "dateTime"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("address");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Address"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("telephone");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Telephone"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("mobile");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Mobile"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("email");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Email"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("url_booking");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "url_booking"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("url_web");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "url_web"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("url_brochure");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "url_brochure"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("price");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Price"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("subscription");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Subscription"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("maxParticipants");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "MaxParticipants"));
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
        elemField.setFieldName("views");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Views"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
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

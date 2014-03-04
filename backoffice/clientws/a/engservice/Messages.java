/**
 * Messages.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package net.i2cat.csade.life2.backoffice.clientws.a.engservice;

public class Messages  implements java.io.Serializable {
    private java.lang.String id;

    private int origin;

    private int destination;

    private java.lang.String sname;

    private java.lang.String rname;

    private java.lang.String message;

    private int MRead;

    private java.util.Calendar dateSent;

    private java.util.Calendar dateRead;

    private int MReplied;

    private int idOffer;

    private int idReq;

    public Messages() {
    }

    public Messages(
           java.lang.String id,
           int origin,
           int destination,
           java.lang.String sname,
           java.lang.String rname,
           java.lang.String message,
           int MRead,
           java.util.Calendar dateSent,
           java.util.Calendar dateRead,
           int MReplied,
           int idOffer,
           int idReq) {
           this.id = id;
           this.origin = origin;
           this.destination = destination;
           this.sname = sname;
           this.rname = rname;
           this.message = message;
           this.MRead = MRead;
           this.dateSent = dateSent;
           this.dateRead = dateRead;
           this.MReplied = MReplied;
           this.idOffer = idOffer;
           this.idReq = idReq;
    }


    /**
     * Gets the id value for this Messages.
     * 
     * @return id
     */
    public java.lang.String getId() {
        return id;
    }


    /**
     * Sets the id value for this Messages.
     * 
     * @param id
     */
    public void setId(java.lang.String id) {
        this.id = id;
    }


    /**
     * Gets the origin value for this Messages.
     * 
     * @return origin
     */
    public int getOrigin() {
        return origin;
    }


    /**
     * Sets the origin value for this Messages.
     * 
     * @param origin
     */
    public void setOrigin(int origin) {
        this.origin = origin;
    }


    /**
     * Gets the destination value for this Messages.
     * 
     * @return destination
     */
    public int getDestination() {
        return destination;
    }


    /**
     * Sets the destination value for this Messages.
     * 
     * @param destination
     */
    public void setDestination(int destination) {
        this.destination = destination;
    }


    /**
     * Gets the sname value for this Messages.
     * 
     * @return sname
     */
    public java.lang.String getSname() {
        return sname;
    }


    /**
     * Sets the sname value for this Messages.
     * 
     * @param sname
     */
    public void setSname(java.lang.String sname) {
        this.sname = sname;
    }


    /**
     * Gets the rname value for this Messages.
     * 
     * @return rname
     */
    public java.lang.String getRname() {
        return rname;
    }


    /**
     * Sets the rname value for this Messages.
     * 
     * @param rname
     */
    public void setRname(java.lang.String rname) {
        this.rname = rname;
    }


    /**
     * Gets the message value for this Messages.
     * 
     * @return message
     */
    public java.lang.String getMessage() {
        return message;
    }


    /**
     * Sets the message value for this Messages.
     * 
     * @param message
     */
    public void setMessage(java.lang.String message) {
        this.message = message;
    }


    /**
     * Gets the MRead value for this Messages.
     * 
     * @return MRead
     */
    public int getMRead() {
        return MRead;
    }


    /**
     * Sets the MRead value for this Messages.
     * 
     * @param MRead
     */
    public void setMRead(int MRead) {
        this.MRead = MRead;
    }


    /**
     * Gets the dateSent value for this Messages.
     * 
     * @return dateSent
     */
    public java.util.Calendar getDateSent() {
        return dateSent;
    }


    /**
     * Sets the dateSent value for this Messages.
     * 
     * @param dateSent
     */
    public void setDateSent(java.util.Calendar dateSent) {
        this.dateSent = dateSent;
    }


    /**
     * Gets the dateRead value for this Messages.
     * 
     * @return dateRead
     */
    public java.util.Calendar getDateRead() {
        return dateRead;
    }


    /**
     * Sets the dateRead value for this Messages.
     * 
     * @param dateRead
     */
    public void setDateRead(java.util.Calendar dateRead) {
        this.dateRead = dateRead;
    }


    /**
     * Gets the MReplied value for this Messages.
     * 
     * @return MReplied
     */
    public int getMReplied() {
        return MReplied;
    }


    /**
     * Sets the MReplied value for this Messages.
     * 
     * @param MReplied
     */
    public void setMReplied(int MReplied) {
        this.MReplied = MReplied;
    }


    /**
     * Gets the idOffer value for this Messages.
     * 
     * @return idOffer
     */
    public int getIdOffer() {
        return idOffer;
    }


    /**
     * Sets the idOffer value for this Messages.
     * 
     * @param idOffer
     */
    public void setIdOffer(int idOffer) {
        this.idOffer = idOffer;
    }


    /**
     * Gets the idReq value for this Messages.
     * 
     * @return idReq
     */
    public int getIdReq() {
        return idReq;
    }


    /**
     * Sets the idReq value for this Messages.
     * 
     * @param idReq
     */
    public void setIdReq(int idReq) {
        this.idReq = idReq;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof Messages)) return false;
        Messages other = (Messages) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.id==null && other.getId()==null) || 
             (this.id!=null &&
              this.id.equals(other.getId()))) &&
            this.origin == other.getOrigin() &&
            this.destination == other.getDestination() &&
            ((this.sname==null && other.getSname()==null) || 
             (this.sname!=null &&
              this.sname.equals(other.getSname()))) &&
            ((this.rname==null && other.getRname()==null) || 
             (this.rname!=null &&
              this.rname.equals(other.getRname()))) &&
            ((this.message==null && other.getMessage()==null) || 
             (this.message!=null &&
              this.message.equals(other.getMessage()))) &&
            this.MRead == other.getMRead() &&
            ((this.dateSent==null && other.getDateSent()==null) || 
             (this.dateSent!=null &&
              this.dateSent.equals(other.getDateSent()))) &&
            ((this.dateRead==null && other.getDateRead()==null) || 
             (this.dateRead!=null &&
              this.dateRead.equals(other.getDateRead()))) &&
            this.MReplied == other.getMReplied() &&
            this.idOffer == other.getIdOffer() &&
            this.idReq == other.getIdReq();
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
        if (getId() != null) {
            _hashCode += getId().hashCode();
        }
        _hashCode += getOrigin();
        _hashCode += getDestination();
        if (getSname() != null) {
            _hashCode += getSname().hashCode();
        }
        if (getRname() != null) {
            _hashCode += getRname().hashCode();
        }
        if (getMessage() != null) {
            _hashCode += getMessage().hashCode();
        }
        _hashCode += getMRead();
        if (getDateSent() != null) {
            _hashCode += getDateSent().hashCode();
        }
        if (getDateRead() != null) {
            _hashCode += getDateRead().hashCode();
        }
        _hashCode += getMReplied();
        _hashCode += getIdOffer();
        _hashCode += getIdReq();
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(Messages.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Messages"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("id");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Id"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("origin");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Origin"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("destination");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Destination"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("sname");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Sname"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("rname");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Rname"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("message");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "Message"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("MRead");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "MRead"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("dateSent");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "DateSent"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "dateTime"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("dateRead");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "DateRead"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "dateTime"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("MReplied");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "MReplied"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("idOffer");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "idOffer"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("idReq");
        elemField.setXmlName(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "idReq"));
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

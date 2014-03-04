/**
 * FilteringPrefs.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package net.i2cat.csade.life2.backoffice.clientws.b.engservice;

public class FilteringPrefs implements java.io.Serializable {
    private java.lang.String _value_;
    private static java.util.HashMap _table_ = new java.util.HashMap();

    // Constructor
    protected FilteringPrefs(java.lang.String value) {
        _value_ = value;
        _table_.put(_value_,this);
    }

    public static final java.lang.String _male_female = "male_female";
    public static final java.lang.String _closest = "closest";
    public static final java.lang.String _best = "best";
    public static final java.lang.String _recommended = "recommended";
    public static final java.lang.String _my_contacts = "my_contacts";
    public static final FilteringPrefs male_female = new FilteringPrefs(_male_female);
    public static final FilteringPrefs closest = new FilteringPrefs(_closest);
    public static final FilteringPrefs best = new FilteringPrefs(_best);
    public static final FilteringPrefs recommended = new FilteringPrefs(_recommended);
    public static final FilteringPrefs my_contacts = new FilteringPrefs(_my_contacts);
    public java.lang.String getValue() { return _value_;}
    public static FilteringPrefs fromValue(java.lang.String value)
          throws java.lang.IllegalArgumentException {
        FilteringPrefs enumeration = (FilteringPrefs)
            _table_.get(value);
        if (enumeration==null) throw new java.lang.IllegalArgumentException();
        return enumeration;
    }
    public static FilteringPrefs fromString(java.lang.String value)
          throws java.lang.IllegalArgumentException {
        return fromValue(value);
    }
    public boolean equals(java.lang.Object obj) {return (obj == this);}
    public int hashCode() { return toString().hashCode();}
    public java.lang.String toString() { return _value_;}
    public java.lang.Object readResolve() throws java.io.ObjectStreamException { return fromValue(_value_);}
    public static org.apache.axis.encoding.Serializer getSerializer(
           java.lang.String mechType, 
           java.lang.Class _javaType,  
           javax.xml.namespace.QName _xmlType) {
        return 
          new org.apache.axis.encoding.ser.EnumSerializer(
            _javaType, _xmlType);
    }
    public static org.apache.axis.encoding.Deserializer getDeserializer(
           java.lang.String mechType, 
           java.lang.Class _javaType,  
           javax.xml.namespace.QName _xmlType) {
        return 
          new org.apache.axis.encoding.ser.EnumDeserializer(
            _javaType, _xmlType);
    }
    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(FilteringPrefs.class);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "FilteringPrefs"));
    }
    /**
     * Return type metadata object
     */
    public static org.apache.axis.description.TypeDesc getTypeDesc() {
        return typeDesc;
    }

}

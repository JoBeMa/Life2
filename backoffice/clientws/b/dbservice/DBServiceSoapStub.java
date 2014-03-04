/**
 * DBServiceSoapStub.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package net.i2cat.csade.life2.backoffice.clientws.b.dbservice;

public class DBServiceSoapStub extends org.apache.axis.client.Stub implements net.i2cat.csade.life2.backoffice.clientws.b.dbservice.DBServiceSoap {
    private java.util.Vector cachedSerClasses = new java.util.Vector();
    private java.util.Vector cachedSerQNames = new java.util.Vector();
    private java.util.Vector cachedSerFactories = new java.util.Vector();
    private java.util.Vector cachedDeserFactories = new java.util.Vector();

    static org.apache.axis.description.OperationDesc [] _operations;

    static {
        _operations = new org.apache.axis.description.OperationDesc[9];
        _initOperationDesc1();
    }

    private static void _initOperationDesc1(){
        org.apache.axis.description.OperationDesc oper;
        org.apache.axis.description.ParameterDesc param;
        oper = new org.apache.axis.description.OperationDesc();
        oper.setName("dbRegisterUser");
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Login"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Role"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Password"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Name"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "email"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "telephonenumber"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Language"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_lat"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_lon"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_radius"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Notification_level"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "region"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        oper.setReturnType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        oper.setReturnClass(int.class);
        oper.setReturnQName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "dbRegisterUserResult"));
        oper.setStyle(org.apache.axis.constants.Style.WRAPPED);
        oper.setUse(org.apache.axis.constants.Use.LITERAL);
        _operations[0] = oper;

        oper = new org.apache.axis.description.OperationDesc();
        oper.setName("dbUpdateUser");
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Login"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Role"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Password"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Name"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Email"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "telephonenumber"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Picture"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Language"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_lat"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_lon"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_radius"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_timestamp"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_lat"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_lon"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Notification_level"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Promoter_id"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "User_average_mark"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "User_votes"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Enabled"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"), int.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "SkillsVisibility"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"), int.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "InterestsVisibility"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"), int.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "region"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "address"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "adminRegion"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        oper.setReturnType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        oper.setReturnClass(int.class);
        oper.setReturnQName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "dbUpdateUserResult"));
        oper.setStyle(org.apache.axis.constants.Style.WRAPPED);
        oper.setUse(org.apache.axis.constants.Use.LITERAL);
        _operations[1] = oper;

        oper = new org.apache.axis.description.OperationDesc();
        oper.setName("dbUserLogin");
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Login"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Password"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Role"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"), int.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Email"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "telephonenumber"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Name"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Picture"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Language"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_lat"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_lon"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_radius"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_timestamp"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_lat"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_lon"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Notification_level"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Promoter_id"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "User_average_mark"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "User_votes"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Enabled"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"), int.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "region"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        oper.setReturnType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        oper.setReturnClass(int.class);
        oper.setReturnQName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "dbUserLoginResult"));
        oper.setStyle(org.apache.axis.constants.Style.WRAPPED);
        oper.setUse(org.apache.axis.constants.Use.LITERAL);
        _operations[2] = oper;

        oper = new org.apache.axis.description.OperationDesc();
        oper.setName("dbDeleteUser");
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Login"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        oper.setReturnType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        oper.setReturnClass(int.class);
        oper.setReturnQName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "dbDeleteUserResult"));
        oper.setStyle(org.apache.axis.constants.Style.WRAPPED);
        oper.setUse(org.apache.axis.constants.Use.LITERAL);
        _operations[3] = oper;

        oper = new org.apache.axis.description.OperationDesc();
        oper.setName("dbSetSkillsVisiblity");
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Login"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Visibility"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"), int.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        oper.setReturnType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        oper.setReturnClass(int.class);
        oper.setReturnQName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "dbSetSkillsVisiblityResult"));
        oper.setStyle(org.apache.axis.constants.Style.WRAPPED);
        oper.setUse(org.apache.axis.constants.Use.LITERAL);
        _operations[4] = oper;

        oper = new org.apache.axis.description.OperationDesc();
        oper.setName("dbSetInterestsVisiblity");
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Login"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Visibility"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"), int.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        oper.setReturnType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        oper.setReturnClass(int.class);
        oper.setReturnQName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "dbSetInterestsVisiblityResult"));
        oper.setStyle(org.apache.axis.constants.Style.WRAPPED);
        oper.setUse(org.apache.axis.constants.Use.LITERAL);
        _operations[5] = oper;

        oper = new org.apache.axis.description.OperationDesc();
        oper.setName("dbReadUser");
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Login"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Role"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"), int.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Email"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Name"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Picture"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Language"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "telephonenumber"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_lat"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_lon"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_radius"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_timestamp"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_lat"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_lon"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Notification_level"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Promoter_id"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "User_average_mark"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "User_votes"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Enabled"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"), int.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "region"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "address"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "SkillsVisibility"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"), int.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "InterestsVisibility"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"), int.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "adminRegion"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        oper.setReturnType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        oper.setReturnClass(int.class);
        oper.setReturnQName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "dbReadUserResult"));
        oper.setStyle(org.apache.axis.constants.Style.WRAPPED);
        oper.setUse(org.apache.axis.constants.Use.LITERAL);
        _operations[6] = oper;

        oper = new org.apache.axis.description.OperationDesc();
        oper.setName("getUserList");
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "sql"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Ret_UserList"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://Life_2_0_DB/", "ArrayOfUserProfile"), net.i2cat.csade.life2.backoffice.clientws.b.dbservice.UserProfile[].class, false, false);
        param.setItemQName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "UserProfile"));
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "start"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"), int.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "count"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"), int.class, false, false);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "username"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        oper.setReturnType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        oper.setReturnClass(int.class);
        oper.setReturnQName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "getUserListResult"));
        oper.setStyle(org.apache.axis.constants.Style.WRAPPED);
        oper.setUse(org.apache.axis.constants.Use.LITERAL);
        _operations[7] = oper;

        oper = new org.apache.axis.description.OperationDesc();
        oper.setName("UploadPicture");
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Login"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Picture"), org.apache.axis.description.ParameterDesc.IN, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "base64Binary"), byte[].class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        param = new org.apache.axis.description.ParameterDesc(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage"), org.apache.axis.description.ParameterDesc.INOUT, new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "string"), java.lang.String.class, false, false);
        param.setOmittable(true);
        oper.addParameter(param);
        oper.setReturnType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        oper.setReturnClass(int.class);
        oper.setReturnQName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "UploadPictureResult"));
        oper.setStyle(org.apache.axis.constants.Style.WRAPPED);
        oper.setUse(org.apache.axis.constants.Use.LITERAL);
        _operations[8] = oper;

    }

    public DBServiceSoapStub() throws org.apache.axis.AxisFault {
         this(null);
    }

    public DBServiceSoapStub(java.net.URL endpointURL, javax.xml.rpc.Service service) throws org.apache.axis.AxisFault {
         this(service);
         super.cachedEndpoint = endpointURL;
    }

    public DBServiceSoapStub(javax.xml.rpc.Service service) throws org.apache.axis.AxisFault {
        if (service == null) {
            super.service = new org.apache.axis.client.Service();
        } else {
            super.service = service;
        }
        ((org.apache.axis.client.Service)super.service).setTypeMappingVersion("1.2");
            java.lang.Class cls;
            javax.xml.namespace.QName qName;
            javax.xml.namespace.QName qName2;
            java.lang.Class beansf = org.apache.axis.encoding.ser.BeanSerializerFactory.class;
            java.lang.Class beandf = org.apache.axis.encoding.ser.BeanDeserializerFactory.class;
            java.lang.Class enumsf = org.apache.axis.encoding.ser.EnumSerializerFactory.class;
            java.lang.Class enumdf = org.apache.axis.encoding.ser.EnumDeserializerFactory.class;
            java.lang.Class arraysf = org.apache.axis.encoding.ser.ArraySerializerFactory.class;
            java.lang.Class arraydf = org.apache.axis.encoding.ser.ArrayDeserializerFactory.class;
            java.lang.Class simplesf = org.apache.axis.encoding.ser.SimpleSerializerFactory.class;
            java.lang.Class simpledf = org.apache.axis.encoding.ser.SimpleDeserializerFactory.class;
            java.lang.Class simplelistsf = org.apache.axis.encoding.ser.SimpleListSerializerFactory.class;
            java.lang.Class simplelistdf = org.apache.axis.encoding.ser.SimpleListDeserializerFactory.class;
            qName = new javax.xml.namespace.QName("http://Life_2_0_DB/", "ArrayOfUserProfile");
            cachedSerQNames.add(qName);
            cls = net.i2cat.csade.life2.backoffice.clientws.b.dbservice.UserProfile[].class;
            cachedSerClasses.add(cls);
            qName = new javax.xml.namespace.QName("http://Life_2_0_DB/", "UserProfile");
            qName2 = new javax.xml.namespace.QName("http://Life_2_0_DB/", "UserProfile");
            cachedSerFactories.add(new org.apache.axis.encoding.ser.ArraySerializerFactory(qName, qName2));
            cachedDeserFactories.add(new org.apache.axis.encoding.ser.ArrayDeserializerFactory());

            qName = new javax.xml.namespace.QName("http://Life_2_0_DB/", "UserProfile");
            cachedSerQNames.add(qName);
            cls = net.i2cat.csade.life2.backoffice.clientws.b.dbservice.UserProfile.class;
            cachedSerClasses.add(cls);
            cachedSerFactories.add(beansf);
            cachedDeserFactories.add(beandf);

    }

    protected org.apache.axis.client.Call createCall() throws java.rmi.RemoteException {
        try {
            org.apache.axis.client.Call _call = super._createCall();
            if (super.maintainSessionSet) {
                _call.setMaintainSession(super.maintainSession);
            }
            if (super.cachedUsername != null) {
                _call.setUsername(super.cachedUsername);
            }
            if (super.cachedPassword != null) {
                _call.setPassword(super.cachedPassword);
            }
            if (super.cachedEndpoint != null) {
                _call.setTargetEndpointAddress(super.cachedEndpoint);
            }
            if (super.cachedTimeout != null) {
                _call.setTimeout(super.cachedTimeout);
            }
            if (super.cachedPortName != null) {
                _call.setPortName(super.cachedPortName);
            }
            java.util.Enumeration keys = super.cachedProperties.keys();
            while (keys.hasMoreElements()) {
                java.lang.String key = (java.lang.String) keys.nextElement();
                _call.setProperty(key, super.cachedProperties.get(key));
            }
            // All the type mapping information is registered
            // when the first call is made.
            // The type mapping information is actually registered in
            // the TypeMappingRegistry of the service, which
            // is the reason why registration is only needed for the first call.
            synchronized (this) {
                if (firstCall()) {
                    // must set encoding style before registering serializers
                    _call.setEncodingStyle(null);
                    for (int i = 0; i < cachedSerFactories.size(); ++i) {
                        java.lang.Class cls = (java.lang.Class) cachedSerClasses.get(i);
                        javax.xml.namespace.QName qName =
                                (javax.xml.namespace.QName) cachedSerQNames.get(i);
                        java.lang.Object x = cachedSerFactories.get(i);
                        if (x instanceof Class) {
                            java.lang.Class sf = (java.lang.Class)
                                 cachedSerFactories.get(i);
                            java.lang.Class df = (java.lang.Class)
                                 cachedDeserFactories.get(i);
                            _call.registerTypeMapping(cls, qName, sf, df, false);
                        }
                        else if (x instanceof javax.xml.rpc.encoding.SerializerFactory) {
                            org.apache.axis.encoding.SerializerFactory sf = (org.apache.axis.encoding.SerializerFactory)
                                 cachedSerFactories.get(i);
                            org.apache.axis.encoding.DeserializerFactory df = (org.apache.axis.encoding.DeserializerFactory)
                                 cachedDeserFactories.get(i);
                            _call.registerTypeMapping(cls, qName, sf, df, false);
                        }
                    }
                }
            }
            return _call;
        }
        catch (java.lang.Throwable _t) {
            throw new org.apache.axis.AxisFault("Failure trying to get the Call object", _t);
        }
    }

    public int dbRegisterUser(java.lang.String login, java.lang.String role, java.lang.String password, java.lang.String name, java.lang.String email, java.lang.String telephonenumber, java.lang.String language, java.lang.String home_area_lat, java.lang.String home_area_lon, java.lang.String home_area_radius, java.lang.String notification_level, java.lang.String region, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException {
        if (super.cachedEndpoint == null) {
            throw new org.apache.axis.NoEndPointException();
        }
        org.apache.axis.client.Call _call = createCall();
        _call.setOperation(_operations[0]);
        _call.setUseSOAPAction(true);
        _call.setSOAPActionURI("http://Life_2_0_DB/dbRegisterUser");
        _call.setEncodingStyle(null);
        _call.setProperty(org.apache.axis.client.Call.SEND_TYPE_ATTR, Boolean.FALSE);
        _call.setProperty(org.apache.axis.AxisEngine.PROP_DOMULTIREFS, Boolean.FALSE);
        _call.setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
        _call.setOperationName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "dbRegisterUser"));

        setRequestHeaders(_call);
        setAttachments(_call);
 try {        java.lang.Object _resp = _call.invoke(new java.lang.Object[] {login, role, password, name, email, telephonenumber, language, home_area_lat, home_area_lon, home_area_radius, notification_level, region, errorMessage.value});

        if (_resp instanceof java.rmi.RemoteException) {
            throw (java.rmi.RemoteException)_resp;
        }
        else {
            extractAttachments(_call);
            java.util.Map _output;
            _output = _call.getOutputParams();
            try {
                errorMessage.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage"));
            } catch (java.lang.Exception _exception) {
                errorMessage.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage")), java.lang.String.class);
            }
            try {
                return ((java.lang.Integer) _resp).intValue();
            } catch (java.lang.Exception _exception) {
                return ((java.lang.Integer) org.apache.axis.utils.JavaUtils.convert(_resp, int.class)).intValue();
            }
        }
  } catch (org.apache.axis.AxisFault axisFaultException) {
  throw axisFaultException;
}
    }

    public int dbUpdateUser(java.lang.String login, java.lang.String role, java.lang.String password, java.lang.String name, java.lang.String email, java.lang.String telephonenumber, java.lang.String picture, java.lang.String language, java.lang.String home_area_lat, java.lang.String home_area_lon, java.lang.String home_area_radius, java.lang.String last_location_timestamp, java.lang.String last_location_lat, java.lang.String last_location_lon, java.lang.String notification_level, java.lang.String promoter_id, java.lang.String user_average_mark, java.lang.String user_votes, int enabled, int skillsVisibility, int interestsVisibility, java.lang.String region, java.lang.String address, java.lang.String adminRegion, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException {
        if (super.cachedEndpoint == null) {
            throw new org.apache.axis.NoEndPointException();
        }
        org.apache.axis.client.Call _call = createCall();
        _call.setOperation(_operations[1]);
        _call.setUseSOAPAction(true);
        _call.setSOAPActionURI("http://Life_2_0_DB/dbUpdateUser");
        _call.setEncodingStyle(null);
        _call.setProperty(org.apache.axis.client.Call.SEND_TYPE_ATTR, Boolean.FALSE);
        _call.setProperty(org.apache.axis.AxisEngine.PROP_DOMULTIREFS, Boolean.FALSE);
        _call.setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
        _call.setOperationName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "dbUpdateUser"));

        setRequestHeaders(_call);
        setAttachments(_call);
 try {        java.lang.Object _resp = _call.invoke(new java.lang.Object[] {login, role, password, name, email, telephonenumber, picture, language, home_area_lat, home_area_lon, home_area_radius, last_location_timestamp, last_location_lat, last_location_lon, notification_level, promoter_id, user_average_mark, user_votes, new java.lang.Integer(enabled), new java.lang.Integer(skillsVisibility), new java.lang.Integer(interestsVisibility), region, address, adminRegion, errorMessage.value});

        if (_resp instanceof java.rmi.RemoteException) {
            throw (java.rmi.RemoteException)_resp;
        }
        else {
            extractAttachments(_call);
            java.util.Map _output;
            _output = _call.getOutputParams();
            try {
                errorMessage.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage"));
            } catch (java.lang.Exception _exception) {
                errorMessage.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage")), java.lang.String.class);
            }
            try {
                return ((java.lang.Integer) _resp).intValue();
            } catch (java.lang.Exception _exception) {
                return ((java.lang.Integer) org.apache.axis.utils.JavaUtils.convert(_resp, int.class)).intValue();
            }
        }
  } catch (org.apache.axis.AxisFault axisFaultException) {
  throw axisFaultException;
}
    }

    public int dbUserLogin(java.lang.String login, java.lang.String password, javax.xml.rpc.holders.IntHolder role, javax.xml.rpc.holders.StringHolder email, javax.xml.rpc.holders.StringHolder telephonenumber, javax.xml.rpc.holders.StringHolder name, javax.xml.rpc.holders.StringHolder picture, javax.xml.rpc.holders.StringHolder language, javax.xml.rpc.holders.StringHolder home_area_lat, javax.xml.rpc.holders.StringHolder home_area_lon, javax.xml.rpc.holders.StringHolder home_area_radius, javax.xml.rpc.holders.StringHolder last_location_timestamp, javax.xml.rpc.holders.StringHolder last_location_lat, javax.xml.rpc.holders.StringHolder last_location_lon, javax.xml.rpc.holders.StringHolder notification_level, javax.xml.rpc.holders.StringHolder promoter_id, javax.xml.rpc.holders.StringHolder user_average_mark, javax.xml.rpc.holders.StringHolder user_votes, javax.xml.rpc.holders.IntHolder enabled, javax.xml.rpc.holders.StringHolder region, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException {
        if (super.cachedEndpoint == null) {
            throw new org.apache.axis.NoEndPointException();
        }
        org.apache.axis.client.Call _call = createCall();
        _call.setOperation(_operations[2]);
        _call.setUseSOAPAction(true);
        _call.setSOAPActionURI("http://Life_2_0_DB/dbUserLogin");
        _call.setEncodingStyle(null);
        _call.setProperty(org.apache.axis.client.Call.SEND_TYPE_ATTR, Boolean.FALSE);
        _call.setProperty(org.apache.axis.AxisEngine.PROP_DOMULTIREFS, Boolean.FALSE);
        _call.setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
        _call.setOperationName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "dbUserLogin"));

        setRequestHeaders(_call);
        setAttachments(_call);
 try {        java.lang.Object _resp = _call.invoke(new java.lang.Object[] {login, password, new java.lang.Integer(role.value), email.value, telephonenumber.value, name.value, picture.value, language.value, home_area_lat.value, home_area_lon.value, home_area_radius.value, last_location_timestamp.value, last_location_lat.value, last_location_lon.value, notification_level.value, promoter_id.value, user_average_mark.value, user_votes.value, new java.lang.Integer(enabled.value), region.value, errorMessage.value});

        if (_resp instanceof java.rmi.RemoteException) {
            throw (java.rmi.RemoteException)_resp;
        }
        else {
            extractAttachments(_call);
            java.util.Map _output;
            _output = _call.getOutputParams();
            try {
                role.value = ((java.lang.Integer) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Role"))).intValue();
            } catch (java.lang.Exception _exception) {
                role.value = ((java.lang.Integer) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Role")), int.class)).intValue();
            }
            try {
                email.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Email"));
            } catch (java.lang.Exception _exception) {
                email.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Email")), java.lang.String.class);
            }
            try {
                telephonenumber.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "telephonenumber"));
            } catch (java.lang.Exception _exception) {
                telephonenumber.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "telephonenumber")), java.lang.String.class);
            }
            try {
                name.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Name"));
            } catch (java.lang.Exception _exception) {
                name.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Name")), java.lang.String.class);
            }
            try {
                picture.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Picture"));
            } catch (java.lang.Exception _exception) {
                picture.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Picture")), java.lang.String.class);
            }
            try {
                language.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Language"));
            } catch (java.lang.Exception _exception) {
                language.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Language")), java.lang.String.class);
            }
            try {
                home_area_lat.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_lat"));
            } catch (java.lang.Exception _exception) {
                home_area_lat.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_lat")), java.lang.String.class);
            }
            try {
                home_area_lon.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_lon"));
            } catch (java.lang.Exception _exception) {
                home_area_lon.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_lon")), java.lang.String.class);
            }
            try {
                home_area_radius.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_radius"));
            } catch (java.lang.Exception _exception) {
                home_area_radius.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_radius")), java.lang.String.class);
            }
            try {
                last_location_timestamp.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_timestamp"));
            } catch (java.lang.Exception _exception) {
                last_location_timestamp.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_timestamp")), java.lang.String.class);
            }
            try {
                last_location_lat.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_lat"));
            } catch (java.lang.Exception _exception) {
                last_location_lat.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_lat")), java.lang.String.class);
            }
            try {
                last_location_lon.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_lon"));
            } catch (java.lang.Exception _exception) {
                last_location_lon.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_lon")), java.lang.String.class);
            }
            try {
                notification_level.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Notification_level"));
            } catch (java.lang.Exception _exception) {
                notification_level.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Notification_level")), java.lang.String.class);
            }
            try {
                promoter_id.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Promoter_id"));
            } catch (java.lang.Exception _exception) {
                promoter_id.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Promoter_id")), java.lang.String.class);
            }
            try {
                user_average_mark.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "User_average_mark"));
            } catch (java.lang.Exception _exception) {
                user_average_mark.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "User_average_mark")), java.lang.String.class);
            }
            try {
                user_votes.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "User_votes"));
            } catch (java.lang.Exception _exception) {
                user_votes.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "User_votes")), java.lang.String.class);
            }
            try {
                enabled.value = ((java.lang.Integer) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Enabled"))).intValue();
            } catch (java.lang.Exception _exception) {
                enabled.value = ((java.lang.Integer) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Enabled")), int.class)).intValue();
            }
            try {
                region.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "region"));
            } catch (java.lang.Exception _exception) {
                region.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "region")), java.lang.String.class);
            }
            try {
                errorMessage.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage"));
            } catch (java.lang.Exception _exception) {
                errorMessage.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage")), java.lang.String.class);
            }
            try {
                return ((java.lang.Integer) _resp).intValue();
            } catch (java.lang.Exception _exception) {
                return ((java.lang.Integer) org.apache.axis.utils.JavaUtils.convert(_resp, int.class)).intValue();
            }
        }
  } catch (org.apache.axis.AxisFault axisFaultException) {
  throw axisFaultException;
}
    }

    public int dbDeleteUser(java.lang.String login, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException {
        if (super.cachedEndpoint == null) {
            throw new org.apache.axis.NoEndPointException();
        }
        org.apache.axis.client.Call _call = createCall();
        _call.setOperation(_operations[3]);
        _call.setUseSOAPAction(true);
        _call.setSOAPActionURI("http://Life_2_0_DB/dbDeleteUser");
        _call.setEncodingStyle(null);
        _call.setProperty(org.apache.axis.client.Call.SEND_TYPE_ATTR, Boolean.FALSE);
        _call.setProperty(org.apache.axis.AxisEngine.PROP_DOMULTIREFS, Boolean.FALSE);
        _call.setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
        _call.setOperationName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "dbDeleteUser"));

        setRequestHeaders(_call);
        setAttachments(_call);
 try {        java.lang.Object _resp = _call.invoke(new java.lang.Object[] {login, errorMessage.value});

        if (_resp instanceof java.rmi.RemoteException) {
            throw (java.rmi.RemoteException)_resp;
        }
        else {
            extractAttachments(_call);
            java.util.Map _output;
            _output = _call.getOutputParams();
            try {
                errorMessage.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage"));
            } catch (java.lang.Exception _exception) {
                errorMessage.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage")), java.lang.String.class);
            }
            try {
                return ((java.lang.Integer) _resp).intValue();
            } catch (java.lang.Exception _exception) {
                return ((java.lang.Integer) org.apache.axis.utils.JavaUtils.convert(_resp, int.class)).intValue();
            }
        }
  } catch (org.apache.axis.AxisFault axisFaultException) {
  throw axisFaultException;
}
    }

    public int dbSetSkillsVisiblity(java.lang.String login, int visibility, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException {
        if (super.cachedEndpoint == null) {
            throw new org.apache.axis.NoEndPointException();
        }
        org.apache.axis.client.Call _call = createCall();
        _call.setOperation(_operations[4]);
        _call.setUseSOAPAction(true);
        _call.setSOAPActionURI("http://Life_2_0_DB/dbSetSkillsVisiblity");
        _call.setEncodingStyle(null);
        _call.setProperty(org.apache.axis.client.Call.SEND_TYPE_ATTR, Boolean.FALSE);
        _call.setProperty(org.apache.axis.AxisEngine.PROP_DOMULTIREFS, Boolean.FALSE);
        _call.setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
        _call.setOperationName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "dbSetSkillsVisiblity"));

        setRequestHeaders(_call);
        setAttachments(_call);
 try {        java.lang.Object _resp = _call.invoke(new java.lang.Object[] {login, new java.lang.Integer(visibility), errorMessage.value});

        if (_resp instanceof java.rmi.RemoteException) {
            throw (java.rmi.RemoteException)_resp;
        }
        else {
            extractAttachments(_call);
            java.util.Map _output;
            _output = _call.getOutputParams();
            try {
                errorMessage.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage"));
            } catch (java.lang.Exception _exception) {
                errorMessage.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage")), java.lang.String.class);
            }
            try {
                return ((java.lang.Integer) _resp).intValue();
            } catch (java.lang.Exception _exception) {
                return ((java.lang.Integer) org.apache.axis.utils.JavaUtils.convert(_resp, int.class)).intValue();
            }
        }
  } catch (org.apache.axis.AxisFault axisFaultException) {
  throw axisFaultException;
}
    }

    public int dbSetInterestsVisiblity(java.lang.String login, int visibility, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException {
        if (super.cachedEndpoint == null) {
            throw new org.apache.axis.NoEndPointException();
        }
        org.apache.axis.client.Call _call = createCall();
        _call.setOperation(_operations[5]);
        _call.setUseSOAPAction(true);
        _call.setSOAPActionURI("http://Life_2_0_DB/dbSetInterestsVisiblity");
        _call.setEncodingStyle(null);
        _call.setProperty(org.apache.axis.client.Call.SEND_TYPE_ATTR, Boolean.FALSE);
        _call.setProperty(org.apache.axis.AxisEngine.PROP_DOMULTIREFS, Boolean.FALSE);
        _call.setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
        _call.setOperationName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "dbSetInterestsVisiblity"));

        setRequestHeaders(_call);
        setAttachments(_call);
 try {        java.lang.Object _resp = _call.invoke(new java.lang.Object[] {login, new java.lang.Integer(visibility), errorMessage.value});

        if (_resp instanceof java.rmi.RemoteException) {
            throw (java.rmi.RemoteException)_resp;
        }
        else {
            extractAttachments(_call);
            java.util.Map _output;
            _output = _call.getOutputParams();
            try {
                errorMessage.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage"));
            } catch (java.lang.Exception _exception) {
                errorMessage.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage")), java.lang.String.class);
            }
            try {
                return ((java.lang.Integer) _resp).intValue();
            } catch (java.lang.Exception _exception) {
                return ((java.lang.Integer) org.apache.axis.utils.JavaUtils.convert(_resp, int.class)).intValue();
            }
        }
  } catch (org.apache.axis.AxisFault axisFaultException) {
  throw axisFaultException;
}
    }

    public int dbReadUser(java.lang.String login, javax.xml.rpc.holders.IntHolder role, javax.xml.rpc.holders.StringHolder email, javax.xml.rpc.holders.StringHolder name, javax.xml.rpc.holders.StringHolder picture, javax.xml.rpc.holders.StringHolder language, javax.xml.rpc.holders.StringHolder telephonenumber, javax.xml.rpc.holders.StringHolder home_area_lat, javax.xml.rpc.holders.StringHolder home_area_lon, javax.xml.rpc.holders.StringHolder home_area_radius, javax.xml.rpc.holders.StringHolder last_location_timestamp, javax.xml.rpc.holders.StringHolder last_location_lat, javax.xml.rpc.holders.StringHolder last_location_lon, javax.xml.rpc.holders.StringHolder notification_level, javax.xml.rpc.holders.StringHolder promoter_id, javax.xml.rpc.holders.StringHolder user_average_mark, javax.xml.rpc.holders.StringHolder user_votes, javax.xml.rpc.holders.IntHolder enabled, javax.xml.rpc.holders.StringHolder region, javax.xml.rpc.holders.StringHolder address, javax.xml.rpc.holders.IntHolder skillsVisibility, javax.xml.rpc.holders.IntHolder interestsVisibility, javax.xml.rpc.holders.StringHolder adminRegion, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException {
        if (super.cachedEndpoint == null) {
            throw new org.apache.axis.NoEndPointException();
        }
        org.apache.axis.client.Call _call = createCall();
        _call.setOperation(_operations[6]);
        _call.setUseSOAPAction(true);
        _call.setSOAPActionURI("http://Life_2_0_DB/dbReadUser");
        _call.setEncodingStyle(null);
        _call.setProperty(org.apache.axis.client.Call.SEND_TYPE_ATTR, Boolean.FALSE);
        _call.setProperty(org.apache.axis.AxisEngine.PROP_DOMULTIREFS, Boolean.FALSE);
        _call.setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
        _call.setOperationName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "dbReadUser"));

        setRequestHeaders(_call);
        setAttachments(_call);
 try {        java.lang.Object _resp = _call.invoke(new java.lang.Object[] {login, new java.lang.Integer(role.value), email.value, name.value, picture.value, language.value, telephonenumber.value, home_area_lat.value, home_area_lon.value, home_area_radius.value, last_location_timestamp.value, last_location_lat.value, last_location_lon.value, notification_level.value, promoter_id.value, user_average_mark.value, user_votes.value, new java.lang.Integer(enabled.value), region.value, address.value, new java.lang.Integer(skillsVisibility.value), new java.lang.Integer(interestsVisibility.value), adminRegion.value, errorMessage.value});

        if (_resp instanceof java.rmi.RemoteException) {
            throw (java.rmi.RemoteException)_resp;
        }
        else {
            extractAttachments(_call);
            java.util.Map _output;
            _output = _call.getOutputParams();
            try {
                role.value = ((java.lang.Integer) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Role"))).intValue();
            } catch (java.lang.Exception _exception) {
                role.value = ((java.lang.Integer) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Role")), int.class)).intValue();
            }
            try {
                email.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Email"));
            } catch (java.lang.Exception _exception) {
                email.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Email")), java.lang.String.class);
            }
            try {
                name.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Name"));
            } catch (java.lang.Exception _exception) {
                name.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Name")), java.lang.String.class);
            }
            try {
                picture.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Picture"));
            } catch (java.lang.Exception _exception) {
                picture.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Picture")), java.lang.String.class);
            }
            try {
                language.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Language"));
            } catch (java.lang.Exception _exception) {
                language.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Language")), java.lang.String.class);
            }
            try {
                telephonenumber.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "telephonenumber"));
            } catch (java.lang.Exception _exception) {
                telephonenumber.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "telephonenumber")), java.lang.String.class);
            }
            try {
                home_area_lat.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_lat"));
            } catch (java.lang.Exception _exception) {
                home_area_lat.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_lat")), java.lang.String.class);
            }
            try {
                home_area_lon.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_lon"));
            } catch (java.lang.Exception _exception) {
                home_area_lon.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_lon")), java.lang.String.class);
            }
            try {
                home_area_radius.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_radius"));
            } catch (java.lang.Exception _exception) {
                home_area_radius.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Home_area_radius")), java.lang.String.class);
            }
            try {
                last_location_timestamp.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_timestamp"));
            } catch (java.lang.Exception _exception) {
                last_location_timestamp.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_timestamp")), java.lang.String.class);
            }
            try {
                last_location_lat.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_lat"));
            } catch (java.lang.Exception _exception) {
                last_location_lat.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_lat")), java.lang.String.class);
            }
            try {
                last_location_lon.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_lon"));
            } catch (java.lang.Exception _exception) {
                last_location_lon.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Last_location_lon")), java.lang.String.class);
            }
            try {
                notification_level.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Notification_level"));
            } catch (java.lang.Exception _exception) {
                notification_level.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Notification_level")), java.lang.String.class);
            }
            try {
                promoter_id.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Promoter_id"));
            } catch (java.lang.Exception _exception) {
                promoter_id.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Promoter_id")), java.lang.String.class);
            }
            try {
                user_average_mark.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "User_average_mark"));
            } catch (java.lang.Exception _exception) {
                user_average_mark.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "User_average_mark")), java.lang.String.class);
            }
            try {
                user_votes.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "User_votes"));
            } catch (java.lang.Exception _exception) {
                user_votes.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "User_votes")), java.lang.String.class);
            }
            try {
                enabled.value = ((java.lang.Integer) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Enabled"))).intValue();
            } catch (java.lang.Exception _exception) {
                enabled.value = ((java.lang.Integer) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Enabled")), int.class)).intValue();
            }
            try {
                region.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "region"));
            } catch (java.lang.Exception _exception) {
                region.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "region")), java.lang.String.class);
            }
            try {
                address.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "address"));
            } catch (java.lang.Exception _exception) {
                address.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "address")), java.lang.String.class);
            }
            try {
                skillsVisibility.value = ((java.lang.Integer) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "SkillsVisibility"))).intValue();
            } catch (java.lang.Exception _exception) {
                skillsVisibility.value = ((java.lang.Integer) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "SkillsVisibility")), int.class)).intValue();
            }
            try {
                interestsVisibility.value = ((java.lang.Integer) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "InterestsVisibility"))).intValue();
            } catch (java.lang.Exception _exception) {
                interestsVisibility.value = ((java.lang.Integer) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "InterestsVisibility")), int.class)).intValue();
            }
            try {
                adminRegion.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "adminRegion"));
            } catch (java.lang.Exception _exception) {
                adminRegion.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "adminRegion")), java.lang.String.class);
            }
            try {
                errorMessage.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage"));
            } catch (java.lang.Exception _exception) {
                errorMessage.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage")), java.lang.String.class);
            }
            try {
                return ((java.lang.Integer) _resp).intValue();
            } catch (java.lang.Exception _exception) {
                return ((java.lang.Integer) org.apache.axis.utils.JavaUtils.convert(_resp, int.class)).intValue();
            }
        }
  } catch (org.apache.axis.AxisFault axisFaultException) {
  throw axisFaultException;
}
    }

    public int getUserList(java.lang.String sql, net.i2cat.csade.life2.backoffice.clientws.b.dbservice.holders.ArrayOfUserProfileHolder ret_UserList, int start, int count, java.lang.String username, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException {
        if (super.cachedEndpoint == null) {
            throw new org.apache.axis.NoEndPointException();
        }
        org.apache.axis.client.Call _call = createCall();
        _call.setOperation(_operations[7]);
        _call.setUseSOAPAction(true);
        _call.setSOAPActionURI("http://Life_2_0_DB/getUserList");
        _call.setEncodingStyle(null);
        _call.setProperty(org.apache.axis.client.Call.SEND_TYPE_ATTR, Boolean.FALSE);
        _call.setProperty(org.apache.axis.AxisEngine.PROP_DOMULTIREFS, Boolean.FALSE);
        _call.setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
        _call.setOperationName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "getUserList"));

        setRequestHeaders(_call);
        setAttachments(_call);
 try {        java.lang.Object _resp = _call.invoke(new java.lang.Object[] {sql, ret_UserList.value, new java.lang.Integer(start), new java.lang.Integer(count), username, errorMessage.value});

        if (_resp instanceof java.rmi.RemoteException) {
            throw (java.rmi.RemoteException)_resp;
        }
        else {
            extractAttachments(_call);
            java.util.Map _output;
            _output = _call.getOutputParams();
            try {
                ret_UserList.value = (net.i2cat.csade.life2.backoffice.clientws.b.dbservice.UserProfile[]) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Ret_UserList"));
            } catch (java.lang.Exception _exception) {
                ret_UserList.value = (net.i2cat.csade.life2.backoffice.clientws.b.dbservice.UserProfile[]) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "Ret_UserList")), net.i2cat.csade.life2.backoffice.clientws.b.dbservice.UserProfile[].class);
            }
            try {
                errorMessage.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage"));
            } catch (java.lang.Exception _exception) {
                errorMessage.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage")), java.lang.String.class);
            }
            try {
                return ((java.lang.Integer) _resp).intValue();
            } catch (java.lang.Exception _exception) {
                return ((java.lang.Integer) org.apache.axis.utils.JavaUtils.convert(_resp, int.class)).intValue();
            }
        }
  } catch (org.apache.axis.AxisFault axisFaultException) {
  throw axisFaultException;
}
    }

    public int uploadPicture(java.lang.String login, byte[] picture, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException {
        if (super.cachedEndpoint == null) {
            throw new org.apache.axis.NoEndPointException();
        }
        org.apache.axis.client.Call _call = createCall();
        _call.setOperation(_operations[8]);
        _call.setUseSOAPAction(true);
        _call.setSOAPActionURI("http://Life_2_0_DB/UploadPicture");
        _call.setEncodingStyle(null);
        _call.setProperty(org.apache.axis.client.Call.SEND_TYPE_ATTR, Boolean.FALSE);
        _call.setProperty(org.apache.axis.AxisEngine.PROP_DOMULTIREFS, Boolean.FALSE);
        _call.setSOAPVersion(org.apache.axis.soap.SOAPConstants.SOAP11_CONSTANTS);
        _call.setOperationName(new javax.xml.namespace.QName("http://Life_2_0_DB/", "UploadPicture"));

        setRequestHeaders(_call);
        setAttachments(_call);
 try {        java.lang.Object _resp = _call.invoke(new java.lang.Object[] {login, picture, errorMessage.value});

        if (_resp instanceof java.rmi.RemoteException) {
            throw (java.rmi.RemoteException)_resp;
        }
        else {
            extractAttachments(_call);
            java.util.Map _output;
            _output = _call.getOutputParams();
            try {
                errorMessage.value = (java.lang.String) _output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage"));
            } catch (java.lang.Exception _exception) {
                errorMessage.value = (java.lang.String) org.apache.axis.utils.JavaUtils.convert(_output.get(new javax.xml.namespace.QName("http://Life_2_0_DB/", "ErrorMessage")), java.lang.String.class);
            }
            try {
                return ((java.lang.Integer) _resp).intValue();
            } catch (java.lang.Exception _exception) {
                return ((java.lang.Integer) org.apache.axis.utils.JavaUtils.convert(_resp, int.class)).intValue();
            }
        }
  } catch (org.apache.axis.AxisFault axisFaultException) {
  throw axisFaultException;
}
    }

}

/**
 * ENGServiceLocator.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package net.i2cat.csade.life2.backoffice.clientws.b.engservice;

public class ENGServiceLocator extends org.apache.axis.client.Service implements net.i2cat.csade.life2.backoffice.clientws.b.engservice.ENGService {

    public ENGServiceLocator() {
    }


    public ENGServiceLocator(org.apache.axis.EngineConfiguration config) {
        super(config);
    }

    public ENGServiceLocator(java.lang.String wsdlLoc, javax.xml.namespace.QName sName) throws javax.xml.rpc.ServiceException {
        super(wsdlLoc, sName);
    }

    // Use to get a proxy class for ENGServiceSoap
    private java.lang.String ENGServiceSoap_address = "http://84.88.40.54/Life20b/Engine/ENGService.asmx";

    public java.lang.String getENGServiceSoapAddress() {
        return ENGServiceSoap_address;
    }

    // The WSDD service name defaults to the port name.
    private java.lang.String ENGServiceSoapWSDDServiceName = "ENGServiceSoap";

    public java.lang.String getENGServiceSoapWSDDServiceName() {
        return ENGServiceSoapWSDDServiceName;
    }

    public void setENGServiceSoapWSDDServiceName(java.lang.String name) {
        ENGServiceSoapWSDDServiceName = name;
    }

    public net.i2cat.csade.life2.backoffice.clientws.b.engservice.ENGServiceSoap getENGServiceSoap() throws javax.xml.rpc.ServiceException {
       java.net.URL endpoint;
        try {
            endpoint = new java.net.URL(ENGServiceSoap_address);
        }
        catch (java.net.MalformedURLException e) {
            throw new javax.xml.rpc.ServiceException(e);
        }
        return getENGServiceSoap(endpoint);
    }

    public net.i2cat.csade.life2.backoffice.clientws.b.engservice.ENGServiceSoap getENGServiceSoap(java.net.URL portAddress) throws javax.xml.rpc.ServiceException {
        try {
            net.i2cat.csade.life2.backoffice.clientws.b.engservice.ENGServiceSoapStub _stub = new net.i2cat.csade.life2.backoffice.clientws.b.engservice.ENGServiceSoapStub(portAddress, this);
            _stub.setPortName(getENGServiceSoapWSDDServiceName());
            return _stub;
        }
        catch (org.apache.axis.AxisFault e) {
            return null;
        }
    }

    public void setENGServiceSoapEndpointAddress(java.lang.String address) {
        ENGServiceSoap_address = address;
    }

    /**
     * For the given interface, get the stub implementation.
     * If this service has no port for the given interface,
     * then ServiceException is thrown.
     */
    public java.rmi.Remote getPort(Class serviceEndpointInterface) throws javax.xml.rpc.ServiceException {
        try {
            if (net.i2cat.csade.life2.backoffice.clientws.b.engservice.ENGServiceSoap.class.isAssignableFrom(serviceEndpointInterface)) {
                net.i2cat.csade.life2.backoffice.clientws.b.engservice.ENGServiceSoapStub _stub = new net.i2cat.csade.life2.backoffice.clientws.b.engservice.ENGServiceSoapStub(new java.net.URL(ENGServiceSoap_address), this);
                _stub.setPortName(getENGServiceSoapWSDDServiceName());
                return _stub;
            }
        }
        catch (java.lang.Throwable t) {
            throw new javax.xml.rpc.ServiceException(t);
        }
        throw new javax.xml.rpc.ServiceException("There is no stub implementation for the interface:  " + (serviceEndpointInterface == null ? "null" : serviceEndpointInterface.getName()));
    }

    /**
     * For the given interface, get the stub implementation.
     * If this service has no port for the given interface,
     * then ServiceException is thrown.
     */
    public java.rmi.Remote getPort(javax.xml.namespace.QName portName, Class serviceEndpointInterface) throws javax.xml.rpc.ServiceException {
        if (portName == null) {
            return getPort(serviceEndpointInterface);
        }
        java.lang.String inputPortName = portName.getLocalPart();
        if ("ENGServiceSoap".equals(inputPortName)) {
            return getENGServiceSoap();
        }
        else  {
            java.rmi.Remote _stub = getPort(serviceEndpointInterface);
            ((org.apache.axis.client.Stub) _stub).setPortName(portName);
            return _stub;
        }
    }

    public javax.xml.namespace.QName getServiceName() {
        return new javax.xml.namespace.QName("http://Life_2_0_Engine/", "ENGService");
    }

    private java.util.HashSet ports = null;

    public java.util.Iterator getPorts() {
        if (ports == null) {
            ports = new java.util.HashSet();
            ports.add(new javax.xml.namespace.QName("http://Life_2_0_Engine/", "ENGServiceSoap"));
        }
        return ports.iterator();
    }

    /**
    * Set the endpoint address for the specified port name.
    */
    public void setEndpointAddress(java.lang.String portName, java.lang.String address) throws javax.xml.rpc.ServiceException {
        
if ("ENGServiceSoap".equals(portName)) {
            setENGServiceSoapEndpointAddress(address);
        }
        else 
{ // Unknown Port Name
            throw new javax.xml.rpc.ServiceException(" Cannot set Endpoint Address for Unknown Port" + portName);
        }
    }

    /**
    * Set the endpoint address for the specified port name.
    */
    public void setEndpointAddress(javax.xml.namespace.QName portName, java.lang.String address) throws javax.xml.rpc.ServiceException {
        setEndpointAddress(portName.getLocalPart(), address);
    }

}

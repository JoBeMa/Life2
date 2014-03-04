package net.i2cat.csade.life2.backoffice.clientws.b.dbservice;

public class DBServiceSoapProxy implements net.i2cat.csade.life2.backoffice.clientws.b.dbservice.DBServiceSoap {
  private String _endpoint = null;
  private net.i2cat.csade.life2.backoffice.clientws.b.dbservice.DBServiceSoap dBServiceSoap = null;
  
  public DBServiceSoapProxy() {
    _initDBServiceSoapProxy();
  }
  
  public DBServiceSoapProxy(String endpoint) {
    _endpoint = endpoint;
    _initDBServiceSoapProxy();
  }
  
  private void _initDBServiceSoapProxy() {
    try {
      dBServiceSoap = (new net.i2cat.csade.life2.backoffice.clientws.b.dbservice.DBServiceLocator()).getDBServiceSoap();
      if (dBServiceSoap != null) {
        if (_endpoint != null)
          ((javax.xml.rpc.Stub)dBServiceSoap)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
        else
          _endpoint = (String)((javax.xml.rpc.Stub)dBServiceSoap)._getProperty("javax.xml.rpc.service.endpoint.address");
      }
      
    }
    catch (javax.xml.rpc.ServiceException serviceException) {}
  }
  
  public String getEndpoint() {
    return _endpoint;
  }
  
  public void setEndpoint(String endpoint) {
    _endpoint = endpoint;
    if (dBServiceSoap != null)
      ((javax.xml.rpc.Stub)dBServiceSoap)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
    
  }
  
  public net.i2cat.csade.life2.backoffice.clientws.b.dbservice.DBServiceSoap getDBServiceSoap() {
    if (dBServiceSoap == null)
      _initDBServiceSoapProxy();
    return dBServiceSoap;
  }
  
  public int dbRegisterUser(java.lang.String login, java.lang.String role, java.lang.String password, java.lang.String name, java.lang.String email, java.lang.String telephonenumber, java.lang.String language, java.lang.String home_area_lat, java.lang.String home_area_lon, java.lang.String home_area_radius, java.lang.String notification_level, java.lang.String region, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (dBServiceSoap == null)
      _initDBServiceSoapProxy();
    return dBServiceSoap.dbRegisterUser(login, role, password, name, email, telephonenumber, language, home_area_lat, home_area_lon, home_area_radius, notification_level, region, errorMessage);
  }
  
  public int dbUpdateUser(java.lang.String login, java.lang.String role, java.lang.String password, java.lang.String name, java.lang.String email, java.lang.String telephonenumber, java.lang.String picture, java.lang.String language, java.lang.String home_area_lat, java.lang.String home_area_lon, java.lang.String home_area_radius, java.lang.String last_location_timestamp, java.lang.String last_location_lat, java.lang.String last_location_lon, java.lang.String notification_level, java.lang.String promoter_id, java.lang.String user_average_mark, java.lang.String user_votes, int enabled, int skillsVisibility, int interestsVisibility, java.lang.String region, java.lang.String address, java.lang.String adminRegion, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (dBServiceSoap == null)
      _initDBServiceSoapProxy();
    return dBServiceSoap.dbUpdateUser(login, role, password, name, email, telephonenumber, picture, language, home_area_lat, home_area_lon, home_area_radius, last_location_timestamp, last_location_lat, last_location_lon, notification_level, promoter_id, user_average_mark, user_votes, enabled, skillsVisibility, interestsVisibility, region, address, adminRegion, errorMessage);
  }
  
  public int dbUserLogin(java.lang.String login, java.lang.String password, javax.xml.rpc.holders.IntHolder role, javax.xml.rpc.holders.StringHolder email, javax.xml.rpc.holders.StringHolder telephonenumber, javax.xml.rpc.holders.StringHolder name, javax.xml.rpc.holders.StringHolder picture, javax.xml.rpc.holders.StringHolder language, javax.xml.rpc.holders.StringHolder home_area_lat, javax.xml.rpc.holders.StringHolder home_area_lon, javax.xml.rpc.holders.StringHolder home_area_radius, javax.xml.rpc.holders.StringHolder last_location_timestamp, javax.xml.rpc.holders.StringHolder last_location_lat, javax.xml.rpc.holders.StringHolder last_location_lon, javax.xml.rpc.holders.StringHolder notification_level, javax.xml.rpc.holders.StringHolder promoter_id, javax.xml.rpc.holders.StringHolder user_average_mark, javax.xml.rpc.holders.StringHolder user_votes, javax.xml.rpc.holders.IntHolder enabled, javax.xml.rpc.holders.StringHolder region, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (dBServiceSoap == null)
      _initDBServiceSoapProxy();
    return dBServiceSoap.dbUserLogin(login, password, role, email, telephonenumber, name, picture, language, home_area_lat, home_area_lon, home_area_radius, last_location_timestamp, last_location_lat, last_location_lon, notification_level, promoter_id, user_average_mark, user_votes, enabled, region, errorMessage);
  }
  
  public int dbDeleteUser(java.lang.String login, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (dBServiceSoap == null)
      _initDBServiceSoapProxy();
    return dBServiceSoap.dbDeleteUser(login, errorMessage);
  }
  
  public int dbSetSkillsVisiblity(java.lang.String login, int visibility, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (dBServiceSoap == null)
      _initDBServiceSoapProxy();
    return dBServiceSoap.dbSetSkillsVisiblity(login, visibility, errorMessage);
  }
  
  public int dbSetInterestsVisiblity(java.lang.String login, int visibility, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (dBServiceSoap == null)
      _initDBServiceSoapProxy();
    return dBServiceSoap.dbSetInterestsVisiblity(login, visibility, errorMessage);
  }
  
  public int dbReadUser(java.lang.String login, javax.xml.rpc.holders.IntHolder role, javax.xml.rpc.holders.StringHolder email, javax.xml.rpc.holders.StringHolder name, javax.xml.rpc.holders.StringHolder picture, javax.xml.rpc.holders.StringHolder language, javax.xml.rpc.holders.StringHolder telephonenumber, javax.xml.rpc.holders.StringHolder home_area_lat, javax.xml.rpc.holders.StringHolder home_area_lon, javax.xml.rpc.holders.StringHolder home_area_radius, javax.xml.rpc.holders.StringHolder last_location_timestamp, javax.xml.rpc.holders.StringHolder last_location_lat, javax.xml.rpc.holders.StringHolder last_location_lon, javax.xml.rpc.holders.StringHolder notification_level, javax.xml.rpc.holders.StringHolder promoter_id, javax.xml.rpc.holders.StringHolder user_average_mark, javax.xml.rpc.holders.StringHolder user_votes, javax.xml.rpc.holders.IntHolder enabled, javax.xml.rpc.holders.StringHolder region, javax.xml.rpc.holders.StringHolder address, javax.xml.rpc.holders.IntHolder skillsVisibility, javax.xml.rpc.holders.IntHolder interestsVisibility, javax.xml.rpc.holders.StringHolder adminRegion, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (dBServiceSoap == null)
      _initDBServiceSoapProxy();
    return dBServiceSoap.dbReadUser(login, role, email, name, picture, language, telephonenumber, home_area_lat, home_area_lon, home_area_radius, last_location_timestamp, last_location_lat, last_location_lon, notification_level, promoter_id, user_average_mark, user_votes, enabled, region, address, skillsVisibility, interestsVisibility, adminRegion, errorMessage);
  }
  
  public int getUserList(java.lang.String sql, net.i2cat.csade.life2.backoffice.clientws.b.dbservice.holders.ArrayOfUserProfileHolder ret_UserList, int start, int count, java.lang.String username, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (dBServiceSoap == null)
      _initDBServiceSoapProxy();
    return dBServiceSoap.getUserList(sql, ret_UserList, start, count, username, errorMessage);
  }
  
  public int uploadPicture(java.lang.String login, byte[] picture, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (dBServiceSoap == null)
      _initDBServiceSoapProxy();
    return dBServiceSoap.uploadPicture(login, picture, errorMessage);
  }
  
  
}
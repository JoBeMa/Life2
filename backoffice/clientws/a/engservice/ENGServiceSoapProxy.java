package net.i2cat.csade.life2.backoffice.clientws.a.engservice;

public class ENGServiceSoapProxy implements net.i2cat.csade.life2.backoffice.clientws.a.engservice.ENGServiceSoap {
  private String _endpoint = null;
  private net.i2cat.csade.life2.backoffice.clientws.a.engservice.ENGServiceSoap eNGServiceSoap = null;
  
  public ENGServiceSoapProxy() {
    _initENGServiceSoapProxy();
  }
  
  public ENGServiceSoapProxy(String endpoint) {
    _endpoint = endpoint;
    _initENGServiceSoapProxy();
  }
  
  private void _initENGServiceSoapProxy() {
    try {
      eNGServiceSoap = (new net.i2cat.csade.life2.backoffice.clientws.a.engservice.ENGServiceLocator()).getENGServiceSoap();
      if (eNGServiceSoap != null) {
        if (_endpoint != null)
          ((javax.xml.rpc.Stub)eNGServiceSoap)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
        else
          _endpoint = (String)((javax.xml.rpc.Stub)eNGServiceSoap)._getProperty("javax.xml.rpc.service.endpoint.address");
      }
      
    }
    catch (javax.xml.rpc.ServiceException serviceException) {}
  }
  
  public String getEndpoint() {
    return _endpoint;
  }
  
  public void setEndpoint(String endpoint) {
    _endpoint = endpoint;
    if (eNGServiceSoap != null)
      ((javax.xml.rpc.Stub)eNGServiceSoap)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
    
  }
  
  public net.i2cat.csade.life2.backoffice.clientws.a.engservice.ENGServiceSoap getENGServiceSoap() {
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap;
  }
  
  public int submitOffer(java.lang.String login, int request_id, java.lang.String category, java.lang.String short_desc, java.lang.String detailed_info, java.lang.String when_Offer, java.lang.String where_Offer, java.util.Calendar deadline, int contactType, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.submitOffer(login, request_id, category, short_desc, detailed_info, when_Offer, where_Offer, deadline, contactType, errorMessage);
  }
  
  public int getOffer(java.lang.String sql, net.i2cat.csade.life2.backoffice.clientws.a.engservice.holders.ArrayOfOfferHolder ret_Offer, int start, int count, java.lang.String username, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.getOffer(sql, ret_Offer, start, count, username, errorMessage);
  }
  
  public int submitRequest(java.lang.String login, java.lang.String request_Type, java.lang.String category_id, java.lang.String short_description, java.lang.String description, java.lang.String when_request, java.lang.String where, net.i2cat.csade.life2.backoffice.clientws.a.engservice.FilteringPrefs filtering_preferences, java.lang.String deadline, java.lang.String candidates, int contactType, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.submitRequest(login, request_Type, category_id, short_description, description, when_request, where, filtering_preferences, deadline, candidates, contactType, errorMessage);
  }
  
  public int updateRequest(java.lang.String login, java.lang.String request_id, java.lang.String request_Type, java.lang.String category_id, java.lang.String short_description, java.lang.String description, java.lang.String when_request, java.lang.String where, net.i2cat.csade.life2.backoffice.clientws.a.engservice.FilteringPrefs filtering_preferences, java.lang.String deadline, java.lang.String candidates, net.i2cat.csade.life2.backoffice.clientws.a.engservice.Status sStatus, int contactType, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.updateRequest(login, request_id, request_Type, category_id, short_description, description, when_request, where, filtering_preferences, deadline, candidates, sStatus, contactType, errorMessage);
  }
  
  public int deleteRequest(java.lang.String login, java.lang.String request_id, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.deleteRequest(login, request_id, errorMessage);
  }
  
  public int applyForRequest(java.lang.String login, java.lang.String request_id, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.applyForRequest(login, request_id, errorMessage);
  }
  
  public int unApplyForRequest(java.lang.String login, java.lang.String request_id, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.unApplyForRequest(login, request_id, errorMessage);
  }
  
  public int getRequestStatus(java.lang.String login, java.lang.String request_id, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.getRequestStatus(login, request_id, errorMessage);
  }
  
  public int getRequests(java.lang.String sql, net.i2cat.csade.life2.backoffice.clientws.a.engservice.holders.ArrayOfRequestHolder ret_Requests, int start, int count, java.lang.String username, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.getRequests(sql, ret_Requests, start, count, username, errorMessage);
  }
  
  public int getRegions(java.lang.String sql, net.i2cat.csade.life2.backoffice.clientws.a.engservice.holders.ArrayOfRegionsHolder ret_Regions, int start, int count, java.lang.String username, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.getRegions(sql, ret_Regions, start, count, username, errorMessage);
  }
  
  public int getRecommendations(java.lang.String sql, net.i2cat.csade.life2.backoffice.clientws.a.engservice.holders.ArrayOfRecommendationsHolder ret_Recs, int start, int count, java.lang.String username, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.getRecommendations(sql, ret_Recs, start, count, username, errorMessage);
  }
  
  public int joinActivity(java.lang.String login, java.lang.String offer_id, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.joinActivity(login, offer_id, errorMessage);
  }
  
  public int unJoinActivity(java.lang.String login, java.lang.String offer_id, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.unJoinActivity(login, offer_id, errorMessage);
  }
  
  public int moderateJoinActivity(java.lang.String login, java.lang.String offer_id, java.lang.String requested_id, int moderation, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.moderateJoinActivity(login, offer_id, requested_id, moderation, errorMessage);
  }
  
  public int sendFeedback(java.lang.String login, java.lang.String offer_id, int feedback, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.sendFeedback(login, offer_id, feedback, errorMessage);
  }
  
  public int sendRecommendation(java.lang.String login, java.lang.String offer_id, java.lang.String request_id, java.lang.String comment, java.lang.String reclist, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.sendRecommendation(login, offer_id, request_id, comment, reclist, errorMessage);
  }
  
  public int promoterFeedback(java.lang.String login, java.lang.String user_id, int feedback, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.promoterFeedback(login, user_id, feedback, errorMessage);
  }
  
  public int acceptRejectRequest(java.lang.String login, java.lang.String user_id, java.lang.String request_id, int acceptReject, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.acceptRejectRequest(login, user_id, request_id, acceptReject, errorMessage);
  }
  
  public int addSkill(java.lang.String login, java.lang.String skill, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.addSkill(login, skill, errorMessage);
  }
  
  public int addInterest(java.lang.String login, java.lang.String interest, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.addInterest(login, interest, errorMessage);
  }
  
  public int getJoins(java.lang.String sql, net.i2cat.csade.life2.backoffice.clientws.a.engservice.holders.ArrayOfJoinHolder ret_joins, int start, int count, java.lang.String username, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.getJoins(sql, ret_joins, start, count, username, errorMessage);
  }
  
  public int getSkills(java.lang.String sql, net.i2cat.csade.life2.backoffice.clientws.a.engservice.holders.ArrayOfSkillHolder ret_skills, int start, int count, java.lang.String username, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.getSkills(sql, ret_skills, start, count, username, errorMessage);
  }
  
  public int getInterests(java.lang.String sql, net.i2cat.csade.life2.backoffice.clientws.a.engservice.holders.ArrayOfInterestHolder ret_interest, int start, int count, java.lang.String username, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.getInterests(sql, ret_interest, start, count, username, errorMessage);
  }
  
  public int getMessages(java.lang.String sql, net.i2cat.csade.life2.backoffice.clientws.a.engservice.holders.ArrayOfMessagesHolder ret_messages, int start, int count, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.getMessages(sql, ret_messages, start, count, errorMessage);
  }
  
  public int updateMessage(int id, int MRead, int MReplied) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.updateMessage(id, MRead, MReplied);
  }
  
  public int updateSkill(java.lang.String login, java.lang.String skill_id, java.lang.String skill, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.updateSkill(login, skill_id, skill, errorMessage);
  }
  
  public int updateInterest(java.lang.String login, java.lang.String interest_id, java.lang.String interest, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.updateInterest(login, interest_id, interest, errorMessage);
  }
  
  public int deleteSkill(java.lang.String login, java.lang.String skill_id, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.deleteSkill(login, skill_id, errorMessage);
  }
  
  public int deleteMessage(int id, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.deleteMessage(id, errorMessage);
  }
  
  public int deleteInterest(java.lang.String login, java.lang.String interest_id, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.deleteInterest(login, interest_id, errorMessage);
  }
  
  public int addCategory(java.lang.String login, java.lang.String category, java.lang.String category_desc, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.addCategory(login, category, category_desc, errorMessage);
  }
  
  public int addActCategory(java.lang.String login, java.lang.String category, java.lang.String category_desc, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.addActCategory(login, category, category_desc, errorMessage);
  }
  
  public int addCompCategory(java.lang.String login, java.lang.String category, java.lang.String category_desc, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.addCompCategory(login, category, category_desc, errorMessage);
  }
  
  public int addRegion(java.lang.String login, java.lang.String name, java.lang.String country, java.lang.String country_code, java.lang.String lat, java.lang.String lon, java.lang.String radius, java.lang.String lng, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.addRegion(login, name, country, country_code, lat, lon, radius, lng, errorMessage);
  }
  
  public int addHub(java.lang.String login, int user_id, java.lang.String name, int area, java.lang.String lng, int category, java.lang.String address, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.addHub(login, user_id, name, area, lng, category, address, errorMessage);
  }
  
  public int addBusiness(java.lang.String login, int user_id, java.lang.String name, int area, java.lang.String lng, int category, java.lang.String address, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.addBusiness(login, user_id, name, area, lng, category, address, errorMessage);
  }
  
  public int getHub(java.lang.String sql, net.i2cat.csade.life2.backoffice.clientws.a.engservice.holders.ArrayOfHubHolder ret_hub, int start, int count, java.lang.String username, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.getHub(sql, ret_hub, start, count, username, errorMessage);
  }
  
  public int getBusiness(java.lang.String sql, net.i2cat.csade.life2.backoffice.clientws.a.engservice.holders.ArrayOfBusinessHolder ret_business, int start, int count, java.lang.String username, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.getBusiness(sql, ret_business, start, count, username, errorMessage);
  }
  
  public int getCategories(java.lang.String sql, net.i2cat.csade.life2.backoffice.clientws.a.engservice.holders.ArrayOfCategoryHolder ret_categories, int start, int count, java.lang.String username, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.getCategories(sql, ret_categories, start, count, username, errorMessage);
  }
  
  public int getActCategories(java.lang.String sql, net.i2cat.csade.life2.backoffice.clientws.a.engservice.holders.ArrayOfCategoryHolder ret_categories, int start, int count, java.lang.String username, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.getActCategories(sql, ret_categories, start, count, username, errorMessage);
  }
  
  public int getCompCategories(java.lang.String sql, net.i2cat.csade.life2.backoffice.clientws.a.engservice.holders.ArrayOfCategoryHolder ret_categories, int start, int count, java.lang.String username, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.getCompCategories(sql, ret_categories, start, count, username, errorMessage);
  }
  
  public int updateCategory(java.lang.String login, java.lang.String category_id, java.lang.String category_name, java.lang.String category_desc, int status, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.updateCategory(login, category_id, category_name, category_desc, status, errorMessage);
  }
  
  public int updateActCategory(java.lang.String login, java.lang.String category_id, java.lang.String category_name, java.lang.String category_desc, int status, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.updateActCategory(login, category_id, category_name, category_desc, status, errorMessage);
  }
  
  public int updateCompCategory(java.lang.String login, java.lang.String category_id, java.lang.String category_name, java.lang.String category_desc, int status, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.updateCompCategory(login, category_id, category_name, category_desc, status, errorMessage);
  }
  
  public int updateRegion(java.lang.String login, java.lang.String id, java.lang.String name, java.lang.String country, java.lang.String country_code, java.lang.String lat, java.lang.String lon, java.lang.String radius, java.lang.String lng, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.updateRegion(login, id, name, country, country_code, lat, lon, radius, lng, errorMessage);
  }
  
  public int deleteRegion(java.lang.String login, java.lang.String id, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.deleteRegion(login, id, errorMessage);
  }
  
  public int deleteCategory(java.lang.String login, java.lang.String category_id, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.deleteCategory(login, category_id, errorMessage);
  }
  
  public int deleteActCategory(java.lang.String login, java.lang.String category_id, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.deleteActCategory(login, category_id, errorMessage);
  }
  
  public int deleteCompCategory(java.lang.String login, java.lang.String category_id, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.deleteCompCategory(login, category_id, errorMessage);
  }
  
  public int deleteRecommendation(java.lang.String login, java.lang.String rec_id, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.deleteRecommendation(login, rec_id, errorMessage);
  }
  
  public int addActivity(java.lang.String login, java.lang.String category, java.lang.String short_desc, java.lang.String detailed_info, java.lang.String when_Activity, java.lang.String where_Activity, java.util.Calendar deadline, int contactType, java.lang.String orgName, java.lang.String title, java.util.Calendar dateOfActivity, java.lang.String address, java.lang.String telephone, java.lang.String price, int subscription, int maxParticipants, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.addActivity(login, category, short_desc, detailed_info, when_Activity, where_Activity, deadline, contactType, orgName, title, dateOfActivity, address, telephone, price, subscription, maxParticipants, errorMessage);
  }
  
  public int addMpOffer(java.lang.String login, java.lang.String category, java.lang.String short_desc, java.lang.String detailed_info, java.lang.String when_MpOffer, java.lang.String where_MpOffer, java.util.Calendar deadline, int contactType, java.lang.String orgName, java.lang.String title, java.util.Calendar dateOfOffer, java.lang.String address, java.lang.String telephone, java.lang.String mobile, java.lang.String email, java.lang.String url_booking, java.lang.String url_web, java.lang.String url_brochure, java.lang.String price, int subscription, int maxParticipants, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.addMpOffer(login, category, short_desc, detailed_info, when_MpOffer, where_MpOffer, deadline, contactType, orgName, title, dateOfOffer, address, telephone, mobile, email, url_booking, url_web, url_brochure, price, subscription, maxParticipants, errorMessage);
  }
  
  public int getActivities(java.lang.String sql, net.i2cat.csade.life2.backoffice.clientws.a.engservice.holders.ArrayOfActivityHolder ret_Activities, int start, int count, java.lang.String username, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.getActivities(sql, ret_Activities, start, count, username, errorMessage);
  }
  
  public int getMpOffers(java.lang.String sql, net.i2cat.csade.life2.backoffice.clientws.a.engservice.holders.ArrayOfMpOfferHolder ret_Activities, int start, int count, java.lang.String username, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.getMpOffers(sql, ret_Activities, start, count, username, errorMessage);
  }
  
  public int updateHub(java.lang.String login, int hub_id, java.lang.String name, int user_id, int area, java.lang.String hub_average_mark, int hub_votes, java.lang.String lng, int category, java.lang.String address, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.updateHub(login, hub_id, name, user_id, area, hub_average_mark, hub_votes, lng, category, address, errorMessage);
  }
  
  public int updateBusiness(java.lang.String login, int SB_id, java.lang.String name, int user_id, int area, java.lang.String SB_average_mark, int SB_votes, java.lang.String lng, int category, java.lang.String address, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.updateBusiness(login, SB_id, name, user_id, area, SB_average_mark, SB_votes, lng, category, address, errorMessage);
  }
  
  public int updateActivity(java.lang.String login, int activity_id, java.lang.String category, java.lang.String short_desc, java.lang.String detailed_info, java.lang.String when_Activity, java.lang.String where_Activity, java.util.Calendar deadline, int contactType, java.lang.String orgName, java.lang.String title, java.util.Calendar dateOfActivity, java.lang.String address, java.lang.String telephone, java.lang.String price, int subscription, int maxParticipants, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.updateActivity(login, activity_id, category, short_desc, detailed_info, when_Activity, where_Activity, deadline, contactType, orgName, title, dateOfActivity, address, telephone, price, subscription, maxParticipants, errorMessage);
  }
  
  public int updateMpOffer(java.lang.String login, int offer_id, java.lang.String category, java.lang.String short_desc, java.lang.String detailed_info, java.lang.String when_Offer, java.lang.String where_Offer, java.util.Calendar deadline, int contactType, java.lang.String orgName, java.lang.String title, java.util.Calendar dateOfOffer, java.lang.String address, java.lang.String telephone, java.lang.String mobile, java.lang.String email, java.lang.String url_booking, java.lang.String url_web, java.lang.String url_brochure, java.lang.String price, int subscription, int maxParticipants, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.updateMpOffer(login, offer_id, category, short_desc, detailed_info, when_Offer, where_Offer, deadline, contactType, orgName, title, dateOfOffer, address, telephone, mobile, email, url_booking, url_web, url_brochure, price, subscription, maxParticipants, errorMessage);
  }
  
  public int viewOffer(java.lang.String login, int offer_id, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.viewOffer(login, offer_id, errorMessage);
  }
  
  public int updateOffer(java.lang.String login, int offer_id, java.lang.String category, java.lang.String short_desc, java.lang.String detailed_info, java.lang.String when_Offer, java.lang.String where_Offer, java.util.Calendar deadline, int contactType, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.updateOffer(login, offer_id, category, short_desc, detailed_info, when_Offer, where_Offer, deadline, contactType, errorMessage);
  }
  
  public int deleteHub(java.lang.String login, int hub_id, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.deleteHub(login, hub_id, errorMessage);
  }
  
  public int deleteBusiness(java.lang.String login, int SB_id, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.deleteBusiness(login, SB_id, errorMessage);
  }
  
  public int deleteActivity(java.lang.String login, int activity_id, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.deleteActivity(login, activity_id, errorMessage);
  }
  
  public int addService(java.lang.String login, java.lang.String category, java.lang.String short_desc, java.lang.String detailed_info, java.lang.String when_Service, java.lang.String where_Service, java.util.Calendar deadline, int contactType, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.addService(login, category, short_desc, detailed_info, when_Service, where_Service, deadline, contactType, errorMessage);
  }
  
  public int getServices(java.lang.String sql, net.i2cat.csade.life2.backoffice.clientws.a.engservice.holders.ArrayOfServiceHolder ret_Services, int start, int count, java.lang.String username, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.getServices(sql, ret_Services, start, count, username, errorMessage);
  }
  
  public int updateService(java.lang.String login, java.lang.String service_id, java.lang.String category, java.lang.String short_desc, java.lang.String detailed_info, java.lang.String when_Service, java.lang.String where_Service, java.util.Calendar deadline, int contactType, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.updateService(login, service_id, category, short_desc, detailed_info, when_Service, where_Service, deadline, contactType, errorMessage);
  }
  
  public int deleteService(java.lang.String login, java.lang.String service_id, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.deleteService(login, service_id, errorMessage);
  }
  
  public int deleteOffer(java.lang.String login, java.lang.String offer_id, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.deleteOffer(login, offer_id, errorMessage);
  }
  
  public int applyForOffer(java.lang.String login, java.lang.String offer_id, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.applyForOffer(login, offer_id, errorMessage);
  }
  
  public int unApplyForOffer(java.lang.String login, java.lang.String offer_id, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.unApplyForOffer(login, offer_id, errorMessage);
  }
  
  public int acceptRejectNewCategory(java.lang.String login, java.lang.String user_id, java.lang.String category_id, int acceptReject, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.acceptRejectNewCategory(login, user_id, category_id, acceptReject, errorMessage);
  }
  
  public int addStat(java.lang.String login, java.lang.String event_id, java.util.Calendar time, int duration, java.lang.String location_lat, java.lang.String location_lon, java.lang.String device, java.lang.String query, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.addStat(login, event_id, time, duration, location_lat, location_lon, device, query, errorMessage);
  }
  
  public int getStats(java.lang.String sql, net.i2cat.csade.life2.backoffice.clientws.a.engservice.holders.ArrayOfStatsHolder ret_Stats, int start, int count, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.getStats(sql, ret_Stats, start, count, errorMessage);
  }
  
  public int getStatsSql(java.lang.String sql, net.i2cat.csade.life2.backoffice.clientws.a.engservice.holders.ArrayOfObjStatsHolder ret_Stats, javax.xml.rpc.holders.StringHolder errorMessage) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.getStatsSql(sql, ret_Stats, errorMessage);
  }
  
  public java.lang.String sendMessage(java.lang.String login, java.lang.String dest, java.lang.String message, int offer_id, int req_id) throws java.rmi.RemoteException{
    if (eNGServiceSoap == null)
      _initENGServiceSoapProxy();
    return eNGServiceSoap.sendMessage(login, dest, message, offer_id, req_id);
  }
  
  
}
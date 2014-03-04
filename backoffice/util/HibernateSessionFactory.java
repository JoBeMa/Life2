/* Life 2.0 Backoffice code Copyright (C) 2014 - Fundaci� i2CAT This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA. */

package net.i2cat.csade.life2.backoffice.util;

import java.util.Properties;

import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.cfg.Configuration;

/**
 * Configures and provides access to Hibernate sessions, tied to the
 * current thread of execution.  Follows the Thread Local Session
 * pattern, see {@link http://hibernate.org/42.html }.
 */
public class HibernateSessionFactory {

        /** 
         * Location of hibernate.cfg.xml file.
         * Location should be on the classpath as Hibernate uses  
         * #resourceAsStream style lookup for its configuration file. 
         * The default classpath location of the hibernate config file is 
         * in the default package. Use #setConfigFile() to update 
         * the location of the configuration file for the current session.   
         */
        private static String CONFIG_FILE_LOCATION = "/conf/hibernate.cfg.xml";
        private static final ThreadLocal<Session> threadLocal = new ThreadLocal<Session>();
        private static Configuration configuration = new Configuration(); 
        private static org.hibernate.SessionFactory sessionFactory;
        private static String configFile = CONFIG_FILE_LOCATION;
        private static String databaseURL = "";

        private HibernateSessionFactory() {
        }
        
        /**
         * Sets database URL (overrides Hibernate configuration).
         * Session factory will be rebuilded in the next call.
         */
        public static void setDatabaseURL(String databaseURL) {
                HibernateSessionFactory.databaseURL = databaseURL;
                closeSession();
                sessionFactory = null;
        }

        /**
         * Returns the ThreadLocal Session instance.  Lazy initialize
         * the <code>SessionFactory</code> if needed.
         *
         *  @return Session
         *  @throws HibernateException
         */
        public static Session getSession() throws HibernateException {
                Session session = (Session) threadLocal.get();

                if (session == null || !session.isOpen()) {
                        if (sessionFactory == null) {
                                rebuildSessionFactory();
                        }
                        session = (sessionFactory != null) ? sessionFactory.openSession()
                                        : null;
                        threadLocal.set(session);
                }

                return session;
        }

        /**
         *  Rebuild hibernate session factory
         *
         */
        public static void rebuildSessionFactory() {
                Properties props;
                
                try {
                        props = new Properties();
                        //props.setProperty("hibernate.connection.url", databaseURL);
                        configuration = new Configuration();
                        configuration.configure(configFile);
                        configuration.addProperties(props);
                        sessionFactory = configuration.buildSessionFactory();
                } catch (Exception e) {
                        System.err.println("%%%% Error Creating SessionFactory %%%%");
                        e.printStackTrace();
                }
        }

        /**
         *  Close the single hibernate session instance.
         *
         *  @throws HibernateException
         */
        public static void closeSession() throws HibernateException {
                Session session = (Session) threadLocal.get();
                threadLocal.set(null);

                if (session != null) {
                        session.close();
                }
        }

        /**
         *  return session factory
         *
         */
        public static org.hibernate.SessionFactory getSessionFactory() {
                return sessionFactory;
        }

        /**
         *  return session factory
         *
         *      session factory will be rebuilded in the next call
         */
        public static void setConfigFile(String configFile) {
                HibernateSessionFactory.configFile = configFile;
                sessionFactory = null;
        }

        /**
         *  return hibernate configuration
         *
         */
        public static Configuration getConfiguration() {
                return configuration;
        }

}
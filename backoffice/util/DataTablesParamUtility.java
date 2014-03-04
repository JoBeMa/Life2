/* Life 2.0 Backoffice code Copyright (C) 2014 - Fundació i2CAT This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA. */

package net.i2cat.csade.life2.backoffice.util;

import javax.servlet.http.HttpServletRequest;

import net.i2cat.csade.life2.backoffice.model.JQueryDataTableParamModel;

public class DataTablesParamUtility {
	
	public static JQueryDataTableParamModel getParam(HttpServletRequest request)
	{
		if(request.getParameter("sEcho")!=null && request.getParameter("sEcho")!= "" && request.getUserPrincipal()!=null  && !"".equals(request.getUserPrincipal()) )
		{
			JQueryDataTableParamModel param = new JQueryDataTableParamModel();
			param.login=request.getUserPrincipal().getName();
			param.sEcho = request.getParameter("sEcho");
			param.sSearch = request.getParameter("sSearch");
			param.sColumns = request.getParameter("sColumns");
			try {
			param.iDisplayStart = Integer.parseInt( request.getParameter("iDisplayStart") );
			param.iDisplayLength = Integer.parseInt( request.getParameter("iDisplayLength") );
			param.iColumns = Integer.parseInt( request.getParameter("iColumns") );
			}
			catch(NumberFormatException iEx) {}
			if (request.getParameter("iSortingCols")!=null && !"".equals(request.getParameter("iSortingCols")))
			{
				param.iSortingCols = Integer.parseInt( request.getParameter("iSortingCols") );
				param.iSortColumnIndex = Integer.parseInt(request.getParameter("iSortCol_0"));
			}
			else
			{
				param.iSortingCols = 0;
				param.iSortColumnIndex = 0;
			}
			param.sSortDirection = request.getParameter("sSortDir_0");
			try 
			{
				param.iRole=Integer.parseInt(request.getParameter("roleFilter"));
			}
			catch(NumberFormatException nfe)
			{
				param.iRole=-1;
			}
			param.sLng=request.getParameter("lngFilter");
			return param;
		}else
			return null;
	}
}

/* Life 2.0 Backoffice code Copyright (C) 2014 - Fundació i2CAT This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA. */

package net.i2cat.csade.life2.backoffice.model;

public class JQueryDataTableParamModel {

	/// <summary>
    /// Request sequence number sent by DataTable, same value must be returned in response
    /// </summary>       
    public String sEcho;

    /// <summary>
    /// Text used for filtering
    /// </summary>
    public String sSearch;

    /// <summary>
    /// Number of records that should be shown in table
    /// </summary>
    public int iDisplayLength;

    /// <summary>
    /// First record that should be shown(used for paging)
    /// </summary>
    public int iDisplayStart;

    /// <summary>
    /// Number of columns in table
    /// </summary>
    public int iColumns;	

    /// <summary>
    /// Number of columns that are used in sorting
    /// </summary>
    public int iSortingCols;
    
    /// <summary>
    /// Index of the column that is used for sorting
    /// </summary>
    public int iSortColumnIndex;
    
    /// <summary>
    /// Sorting direction "asc" or "desc"
    /// </summary>
    public String sSortDirection;

    /// <summary>
    /// Comma separated list of column names
    /// </summary>
    public String sColumns;
    
    /// <summary>
    /// username of the requesting user, for filtering options
    /// </summary>
    public String login;
    
    /// <summary>
    /// role to filter, for filtering options
    /// </summary>
    public int iRole;
    /// <summary>
    /// language to filter, for filtering options
    /// </summary>
	public String sLng;    
    
}

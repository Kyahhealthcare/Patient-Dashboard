using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.Odbc;
using Npgsql;
using System.Net;


/// <summary>
/// Summary description for dataflow
/// </summary>
public class dataflow
{
    public SqlConnection con;
    public SqlConnection con2;
    public NpgsqlConnection postgres;
    public NpgsqlConnection postgres1;
    public dataflow()
    {
        con = new SqlConnection(ConfigurationManager.AppSettings["con"]);
        con2 = new SqlConnection(ConfigurationManager.AppSettings["con2"]);
        postgres = new NpgsqlConnection(ConfigurationManager.AppSettings["postgrate"]);
        postgres1 = new NpgsqlConnection(ConfigurationManager.AppSettings["postgrate1"]);
    }


    public string GetIP()
    {
        string Str = "";
        Str = System.Net.Dns.GetHostName();
        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(Str);
        IPAddress[] addr = ipEntry.AddressList;
        return addr[addr.Length - 1].ToString();

    }
    public void filldropposgress(string sql, string name, string field, ref System.Web.UI.WebControls.DropDownList Drp)
    {
        try
        {
            postgres.Close();
            postgres.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, postgres);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Drp.DataSource = ds;
            Drp.DataTextField = name;
            Drp.DataValueField = field;
            Drp.DataBind();
            postgres.Close();
        }
        catch
        {
            postgres1.Close();
            postgres1.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, postgres1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Drp.DataSource = ds;
            Drp.DataTextField = name;
            Drp.DataValueField = field;
            Drp.DataBind();
            postgres1.Close();

        }
        //Drp.Items.Insert(0, "ALL");
    }
    public void filldrop(string sql, string name, string field, ref System.Web.UI.WebControls.DropDownList Drp)
    {
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        Drp.DataSource = ds;
        Drp.DataTextField = name;
        Drp.DataValueField = field;
        Drp.DataBind();
        con.Close();
        //Drp.Items.Insert(0, "ALL");
    }
    public void fillgrid(string sql, ref System.Web.UI.WebControls.GridView grid)
    {
        SqlDataAdapter ds = new SqlDataAdapter(sql, con);

        DataTable dt = new DataTable();
        ds.Fill(dt);
        grid.DataSource = dt;
        grid.DataBind();

    }
    public void fillgridd(string sql, ref System.Web.UI.WebControls.GridView grid)
    {
        SqlDataAdapter ds = new SqlDataAdapter(sql, con);
        DataTable dt = new DataTable();
        ds.Fill(dt);
        grid.DataSource = dt;
        grid.DataBind();

    }
    public void fillgridposgress(string sql, ref System.Web.UI.WebControls.GridView grid)
    {
        try
        {
            NpgsqlDataAdapter ds = new NpgsqlDataAdapter(sql, postgres);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            grid.DataSource = dt;
            grid.DataBind();
        }
        catch
        {
            NpgsqlDataAdapter ds = new NpgsqlDataAdapter(sql, postgres1);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            grid.DataSource = dt;
            grid.DataBind();
        }

    }
    public void insert(string sql)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.ExecuteNonQuery();
        con.Close();


    }
    public void update(string sql)
    {
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        SqlTransaction trans;
        trans = con.BeginTransaction();
        cmd.Transaction = trans;
        cmd.Connection = con;
        try
        {
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            trans.Commit();
        }
        catch (Exception e)
        {
            trans.Rollback();

        }
        finally
        {
            con.Close();
        }
    }
    public DataSet report(string sql)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter(sql, con);
            ds = new DataSet();
            da.Fill(ds);
        }
        catch (Exception r)
        {

        }
        return ds;
    }

    public decimal autoincrement(string sql)
    {
        decimal code;
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            code = Convert.ToDecimal(dr[0].ToString());
            code = code + 1;
            return code;
            con.Close();
        }
        else
        {
            code = 0001;
            return code;
        }

        con.Close();
    }




    public string getdata(string sql)
    {
        string data = "";
        con.Close();
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            data = dr[0].ToString();
        }
        con.Close();
        dr.Close();
        return data;
    }

    public string getdataposgress(string sql)
    {
        try
        {
            string data = "";
            postgres.Close();
            postgres.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, postgres);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                data = dr[0].ToString();
            }
            postgres.Close();
            dr.Close();
            return data;
        }
        catch
        {
            string data = "";
            postgres1.Close();
            postgres1.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, postgres1);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                data = dr[0].ToString();
            }
            postgres1.Close();
            dr.Close();
            return data;

        }
    }
    public string getdata1(string sql)
    {
        string data = "";
        con2.Close();
        con2.Open();
        SqlCommand cmd = new SqlCommand(sql, con2);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            data = dr[0].ToString();
        }
        con2.Close();
        dr.Close();
        return data;
    }
    public DataTable gettable(string sql)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        try
        {
            da = new SqlDataAdapter(sql, con);
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception r)
        {

        }
        return dt;
    }
    public DataTable gettablecode(string sql)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        try
        {
            da = new SqlDataAdapter(sql, con);
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception r)
        {

        }
        return dt;
    }
    public DataTable table(string sql)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable ds = new DataTable();
        try
        {
            da = new SqlDataAdapter(sql, con);
            ds = new DataTable();
            da.Fill(ds);
        }
        catch (Exception r)
        {

        }
        return ds;
    }
    //public Boolean IsValidUser( string _userid,string _pwd)
    //{
    //    int result = 0;
    //    string strQuery = "Select id From master_login Where user_name = '"+_userid+"' And pwd ='"+_pwd+"' "; 
    //    SqlCommand Cmd = new SqlCommand(strQuery, con);
    //    con.Open();
    //    result = (int)Cmd.ExecuteScalar();
    //    if (result > 0)
    //    {            
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
    public DataTable get_pt_table(string sql)
    {
        try
        {

            NpgsqlDataAdapter da = new NpgsqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                //if (postgres != null)
                //{
                da = new NpgsqlDataAdapter(sql, postgres);
                dt = new DataTable();
                da.Fill(dt);
                //}

            }
            catch (Exception r)
            {

            }
            return dt;


        }

        catch
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                da = new NpgsqlDataAdapter(sql, postgres1);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception r)
            {

            }
            return dt;
        }
    }
}


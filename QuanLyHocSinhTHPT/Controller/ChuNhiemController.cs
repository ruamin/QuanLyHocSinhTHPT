﻿using QuanLyHocSinhTHPT.Helper;
using QuanLyHocSinhTHPT.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace QuanLyHocSinhTHPT.Controller
{
    public class ChuNhiemController
    {
        public static List<GiaoVien> getAllDataChuNhiem()
        {
            using (var db = setupConection.ConnectionFactory())
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                return db.Query<GiaoVien>("SELECT *FROM dbo.GiaoVien").ToList();
            }
        }

        public static void ShowData()
        {
        }

        public bool ThemCN(string _MaGV, string _MaLop, string _NamHoc)
        {
            if (checkInputCN(_MaGV, _MaLop, _NamHoc))
            {
                using (var db = setupConection.ConnectionFactory())
                {
                    try
                    {
                        if (db.State == ConnectionState.Closed)
                            db.Open();
                        using (var transaction = db.BeginTransaction())
                        {
                            int Insert_CN = db.Execute("Name proceduce",
                                new
                                {
                                    //para
                                },
                                commandType: CommandType.StoredProcedure,
                                transaction: transaction);
                            transaction.Commit();
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                    }
                }
                return true;
            }
            return false;
        }

        public bool SuaCN(string _MaGV, string _MaLop, string _NamHoc)
        {
            if (checkInputCN(_MaGV, _MaLop, _NamHoc))
            {
                using (var db = setupConection.ConnectionFactory())
                {
                    try
                    {
                        if (db.State == ConnectionState.Closed)
                            db.Open();
                        using (var transaction = db.BeginTransaction())
                        {
                            int Edit_CN = db.Execute("Name proceduce",
                                new
                                {
                                    //para
                                },
                                commandType: CommandType.StoredProcedure,
                                transaction: transaction);
                            transaction.Commit();
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                    }
                }
                return true;
            }
            return false;
        }

        public bool XoaCN(string _MaGV, string _MaLop)
        {
            if (_MaGV != "")
            {
                using (var db = setupConection.ConnectionFactory())
                {
                    try
                    {
                        if (db.State == ConnectionState.Closed)
                            db.Open();
                        using (var transaction = db.BeginTransaction())
                        {
                            int del_CN = db.Execute("Name proceduce",
                                new
                                {
                                    //para
                                },
                                commandType: CommandType.StoredProcedure,
                                transaction: transaction);
                            transaction.Commit();
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return false;
                    }
                }
                return true;
            }
            return false;
        }

        public static bool checkInputCN(string _MaGV, string _MaLop, string _NamHoc)
        {
            string errMS = "";
            if (_MaGV.Trim() == "") { errMS = "Trống mã giáo viên"; }
            if (_MaLop.Trim() == "") { errMS += "\nTrống Mã Lớp"; }
            if (_NamHoc.Trim() == "") { errMS += "\nTrống năm học"; }
            if (errMS != "")
            {
                MessageBox.Show(errMS, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
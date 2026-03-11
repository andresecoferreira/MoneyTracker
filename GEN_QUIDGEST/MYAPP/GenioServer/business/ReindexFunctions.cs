using ExecuteQueryCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using CSGenio.persistence;
using CSGenio.business;
using CSGenio.framework;
using Quidgest.Persistence.GenericQuery;
using Quidgest.Persistence;

namespace CSGenio.business
{
    public class ReindexFunctions
    {
        public PersistentSupport sp { get; set; }
        public User user { get; set; }
        public bool Zero { get; set; }

        public ReindexFunctions(PersistentSupport sp, User user, bool Zero = false) {
            this.sp = sp;
            this.user = user;
            this.Zero = Zero;
        }   

        public void DeleteInvalidRows(CancellationToken cToken) {
            List<int> zzstateToRemove = new List<int> { 1, 11 };
            DataMatrix dm;
            sp.openConnection();

            /* --- MNTGROUP --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAgroup.FldCodgroup)
                .From(CSGenioAgroup.AreaGROUP)
                .Where(CriteriaSet.And().In(CSGenioAgroup.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAgroup model = new CSGenioAgroup(user);
                model.ValCodgroup = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- MNTMEM --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAmem.FldCodmem)
                .From(CSGenioAmem.AreaMEM)
                .Where(CriteriaSet.And().In(CSGenioAmem.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAmem model = new CSGenioAmem(user);
                model.ValCodmem = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- UserLogin --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioApsw.FldCodpsw)
                .From(CSGenioApsw.AreaPSW)
                .Where(CriteriaSet.And().In(CSGenioApsw.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioApsw model = new CSGenioApsw(user);
                model.ValCodpsw = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcess --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_apr.FldCodascpr)
                .From(CSGenioAs_apr.AreaS_APR)
                .Where(CriteriaSet.And().In(CSGenioAs_apr.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_apr model = new CSGenioAs_apr(user);
                model.ValCodascpr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- NotificationEmailSignature --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_nes.FldCodsigna)
                .From(CSGenioAs_nes.AreaS_NES)
                .Where(CriteriaSet.And().In(CSGenioAs_nes.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_nes model = new CSGenioAs_nes(user);
                model.ValCodsigna = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- NotificationMessage --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_nm.FldCodmesgs)
                .From(CSGenioAs_nm.AreaS_NM)
                .Where(CriteriaSet.And().In(CSGenioAs_nm.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_nm model = new CSGenioAs_nm(user);
                model.ValCodmesgs = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- MNTMEMBER --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAmember.FldCodmember)
                .From(CSGenioAmember.AreaMEMBER)
                .Where(CriteriaSet.And().In(CSGenioAmember.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAmember model = new CSGenioAmember(user);
                model.ValCodmember = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcessArgument --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_arg.FldCodargpr)
                .From(CSGenioAs_arg.AreaS_ARG)
                .Where(CriteriaSet.And().In(CSGenioAs_arg.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_arg model = new CSGenioAs_arg(user);
                model.ValCodargpr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcessAttachments --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_pax.FldCodpranx)
                .From(CSGenioAs_pax.AreaS_PAX)
                .Where(CriteriaSet.And().In(CSGenioAs_pax.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_pax model = new CSGenioAs_pax(user);
                model.ValCodpranx = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- UserAuthorization --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_ua.FldCodua)
                .From(CSGenioAs_ua.AreaS_UA)
                .Where(CriteriaSet.And().In(CSGenioAs_ua.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_ua model = new CSGenioAs_ua(user);
                model.ValCodua = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- MNTACCOUNT --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAaccount.FldCodaccount)
                .From(CSGenioAaccount.AreaACCOUNT)
                .Where(CriteriaSet.And().In(CSGenioAaccount.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAaccount model = new CSGenioAaccount(user);
                model.ValCodaccount = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- MNTMEMBER_PSW --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAmember_psw.FldCodmember_psw)
                .From(CSGenioAmember_psw.AreaMEMBER_PSW)
                .Where(CriteriaSet.And().In(CSGenioAmember_psw.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAmember_psw model = new CSGenioAmember_psw(user);
                model.ValCodmember_psw = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                
            
            //Hard Coded Tabels
            //These can be directly removed

            /* --- MNTmem --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTmem")
                .Where(CriteriaSet.And().In("MNTmem", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTcfg --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTcfg")
                .Where(CriteriaSet.And().In("MNTcfg", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTlstusr --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTlstusr")
                .Where(CriteriaSet.And().In("MNTlstusr", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTlstcol --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTlstcol")
                .Where(CriteriaSet.And().In("MNTlstcol", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTlstren --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTlstren")
                .Where(CriteriaSet.And().In("MNTlstren", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTusrwid --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTusrwid")
                .Where(CriteriaSet.And().In("MNTusrwid", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTusrcfg --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTusrcfg")
                .Where(CriteriaSet.And().In("MNTusrcfg", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTusrset --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTusrset")
                .Where(CriteriaSet.And().In("MNTusrset", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTwkfact --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTwkfact")
                .Where(CriteriaSet.And().In("MNTwkfact", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTwkfcon --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTwkfcon")
                .Where(CriteriaSet.And().In("MNTwkfcon", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTwkflig --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTwkflig")
                .Where(CriteriaSet.And().In("MNTwkflig", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTwkflow --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTwkflow")
                .Where(CriteriaSet.And().In("MNTwkflow", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTnotifi --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTnotifi")
                .Where(CriteriaSet.And().In("MNTnotifi", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTprmfrm --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTprmfrm")
                .Where(CriteriaSet.And().In("MNTprmfrm", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTscrcrd --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTscrcrd")
                .Where(CriteriaSet.And().In("MNTscrcrd", "ZZSTATE", zzstateToRemove)));
                
            /* --- docums --- */
            sp.Execute(new DeleteQuery()
                .Delete("docums")
                .Where(CriteriaSet.And().In("docums", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTpostit --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTpostit")
                .Where(CriteriaSet.And().In("MNTpostit", "ZZSTATE", zzstateToRemove)));
                
            /* --- hashcd --- */
            sp.Execute(new DeleteQuery()
                .Delete("hashcd")
                .Where(CriteriaSet.And().In("hashcd", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTalerta --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTalerta")
                .Where(CriteriaSet.And().In("MNTalerta", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTaltent --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTaltent")
                .Where(CriteriaSet.And().In("MNTaltent", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTtalert --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTtalert")
                .Where(CriteriaSet.And().In("MNTtalert", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTdelega --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTdelega")
                .Where(CriteriaSet.And().In("MNTdelega", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTTABDINAMIC --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTTABDINAMIC")
                .Where(CriteriaSet.And().In("MNTTABDINAMIC", "ZZSTATE", zzstateToRemove)));
                
            /* --- UserAuthorization --- */
            sp.Execute(new DeleteQuery()
                .Delete("UserAuthorization")
                .Where(CriteriaSet.And().In("UserAuthorization", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTaltran --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTaltran")
                .Where(CriteriaSet.And().In("MNTaltran", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTworkflowtask --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTworkflowtask")
                .Where(CriteriaSet.And().In("MNTworkflowtask", "ZZSTATE", zzstateToRemove)));
                
            /* --- MNTworkflowprocess --- */
            sp.Execute(new DeleteQuery()
                .Delete("MNTworkflowprocess")
                .Where(CriteriaSet.And().In("MNTworkflowprocess", "ZZSTATE", zzstateToRemove)));
                

            sp.closeConnection();
        }





        // USE /[MANUAL RDX_STEP]/
    }
}
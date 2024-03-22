using System;
using System.Collections.Generic;
using System.Text;

namespace SLIS.Class
{
  public  class GenericClass
    {
        public string GetTestcode(string tcode)
        {
            if (tcode == "FULL BLOOD COUNT")
            {
                tcode = "FBC";
            }
            else if (tcode == "TCELL PROFILE")
            {
                tcode = "TCELLPR";
            }
            else if (tcode == "BLOOD SMEAR")
            {
                tcode = "BLDSMEAR";
            }
            else if (tcode == "COAGULATION")
            {
                tcode = "COAG";
            }
            else if (tcode == "ABNORMAL RBC'S")
            {
                tcode = "ABRBC";
            }
            else if (tcode == "BLOOD GROUPING")
            {
                tcode = "GPRH";
            }
            else if (tcode == "BLOOD PARASITES")
            {
                tcode = "MLICT";
            }
            else if (tcode == "LIVER FUNCTION TESTS")
            {
                tcode = "LFT";
            }
            else if (tcode == "RENAL FUNCTION TESTS")
            {
                tcode = "REFT";
            }
            else if (tcode == "CAMP")
            {
                tcode = "OTHBLDCHEM";
            }
            else if (tcode == "BLOOD CHEMISTRIES")
            {
                tcode = "OTHBLDCHEM";
            }
            else if (tcode == "BLOOD GLUCOSE")
            {
                tcode = "GCS";
            }
            else if (tcode == "GLUCOSE TOLERANCE TEST")
            {
                tcode = "GCS";
            }
            else if (tcode == "LIPID PROFILE")
            {
                tcode = "LDPD";
            }
            else if (tcode == "CARDIAC ENZYMES")
            {
                tcode = "CDENZ";
            }
            else if (tcode == "AMYLASE")
            {
                tcode = "AMYLS";
            }
            else if (tcode == "URINE CHEMISTRY")
            {
                tcode = "URBCHEM";
            }
            else if (tcode == "HIV PROFILE")
            {
                tcode = "HIV";
            }
            else if (tcode == "HEPATITIS")
            {
                tcode = "HEPSCR";
            }
            else if (tcode == "B-HCG")
            {
                tcode = "PREG";
            }
            else if (tcode == "SYPHILIS")
            {
                tcode = "SYPH";
            }
            else if (tcode == "OTHER SEROLOGY")
            {
                tcode = "ASOT";
            }
            else if (tcode == "CHLAMYDIA")
            {
                tcode = "CLAMY";
            }
            else if (tcode == "FEMALE HORMONES")
            {
                tcode = "FHOMNS";
            }
            else if (tcode == "IMMUNOGLOBULINS")
            {
                tcode = "IMMUNOG";
            }
            else if (tcode == "CYTOLOGY")
            {
                tcode = "CYTO";
            }
            else if (tcode == "HISTOLOGY")
            {
                tcode = "HISTO";
            }
            else if (tcode == "STOOL AND RECTAL MCS")
            {
                tcode = "STMCS";
            }
            else if (tcode == "URINE MCS")
            {
                tcode = "URMCS";
            }
            else if (tcode == "FLUID MCS")
            {
                tcode = "FLDMCS";
            }
            else if (tcode == "BLOOD CULTURE")
            {
                tcode = "BCULT";
            }
            else if (tcode == "SEMEN ANALYSIS MCS")
            {
                tcode = "SEMALYS";
            }
            else if (tcode == "SWAB MCS NO 1")
            {
                tcode = "SWABMCS";
            }
            else if (tcode == "SWAB MCS NO 2")
            {
                tcode = "SWABMCS";
            }
            else if (tcode == "SWAB MCS NO 3")
            {
                tcode = "SWABMCS";
            }
            //else if (tcode == "SEMEN ANALYSIS MCS")
            //{
            //    tcode = "SEMALYS";
            //}
            //else if (tcode == "SEMEN ANALYSIS MCS")
            //{
            //    tcode = "SEMALYS";
            //}
            //else if (tcode == "SEMEN ANALYSIS MCS")
            //{
            //    tcode = "SEMALYS";
            //}
            else
            {
                tcode = tcode;
            }
            return tcode;
        }

        public string GetProfileName(string tcode)
        {
            if (tcode == "FBC")
            {
                tcode = "FULL BLOOD COUNT";
            }
            else if (tcode == "TCELLPR" || tcode == "CD4")
            {
                tcode = "TCELL PROFILE";
            }
            else if (tcode == "BLDSMEAR" )
            {
                tcode = "BLOOD SMEAR";
            }
            else if (tcode == "COAG" )
            {
                tcode = "COAGULATION";
            }
            else if (tcode == "ABRBC" || tcode == "ESR" || tcode == "LECEL" || tcode == "SCELL" || tcode == "RETIC")
            {
                tcode = "ABNORMAL RBC'S";
            }
            else if (tcode == "GPRH" || tcode == "BLOOD GROUP" || tcode == "BDGP")
            {
                tcode = "BLOOD GROUPING";
            }
            else if (tcode == "MLICT" || tcode == "MLSLD" || tcode == "PARASTS")
            {
                tcode = "BLOOD PARASITES";
            }
            else if (tcode == "LFT" )
            {
                tcode = "LIVER FUNCTION TESTS";
            }
            else if (tcode == "REFT" )
            {
                tcode = "RENAL FUNCTION TESTS";
            }
            else if (tcode == "CAL" || tcode == "PO4" || tcode == "MGSM")
            {
                tcode = "CAMP";
            }
            else if (tcode == "OTHBLDCHEM" )
            {
                tcode = "BLOOD CHEMISTRIES";
            }
            else if (tcode == "GCS" || tcode == "GLUCOSE" || tcode == "GTT" || tcode == "RBS" || tcode == "FBS")
            {
                tcode = "BLOOD GLUCOSE";
            }
            //else if (tcode == "GCS" )
            //{
            //    tcode = "GLUCOSE TOLERANCE TEST";
            //}
            else if (tcode == "LDPD" || tcode == "LIPIDS")
            {
                tcode = "LIPID PROFILE";
            }
            else if (tcode == "CDENZ" )
            {
                tcode= "CARDIAC ENZYMES";
            }
            else if (tcode == "AMYLS" )
            {
                tcode = "AMYLASE";
            }
            else if (tcode == "URBCHEM" || tcode == "URALB" || tcode == "URCREAT")
            {
                tcode = "URINE CHEMISTRY";
            }
            else if (tcode == "HIV" || tcode == "HIVDNA" || tcode == "HIVRNA" || tcode == "HIVR")
            {
                tcode = "HIV PROFILE";
            }
            else if (tcode == "HEPSCR" || tcode == "HEPPRO")
            {
                tcode = "HEPATITIS";
            }
            else if (tcode == "PREG" || tcode == "HCGS" || tcode == "HCGU")
            {
                tcode = "B-HCG";
            } 
            else if (tcode.Substring(0, 3) == "SYP")   //string.Substring( int startIndex, int length ) its giving error here
            {
                tcode = "SYPHILIS";
            }
            else if (tcode == "ASOT" || tcode == "BFAT" || tcode == "AFP" || tcode == "WLFLX" || tcode == "HPYLO")
            {
                tcode = "OTHER SEROLOGY";
            }
            else if (tcode == "CLAMY" )
            {
                tcode = "CHLAMYDIA";
            }
            else if (tcode == "FHOMNS")
            {
                tcode = "FEMALE HORMONES";
            }
            else if (tcode == "IMMUNOG" )
            {
                tcode = "IMMUNOGLOBULINS";
            }
            else if (tcode == "CYTO" )
            {
                tcode = "CYTOLOGY";
            }
            else if (tcode == "HISTO")
            {
                tcode = "HISTOLOGY";
            }
            else if (tcode == "STMCS" )
            {
                tcode = "STOOL AND RECTAL MCS";
            }
            else if (tcode == "URMCS"|| tcode == "URCHEM")
            {
                tcode = "URINE MCS";
            }
            else if (tcode == "FLDMCS" )
            {
                tcode = "FLUID MCS";
            }
            else if (tcode == "BCULT" )
            {
                tcode = "BLOOD CULTURE";
            }
            else if (tcode == "SEMALYS" )
            {
                tcode = "SEMEN ANALYSIS MCS";
            }
            else if (tcode == "SWABMCS")
            {
                tcode = "SWAB MCS NO 1";
            }  
            //else if (tcode == "SEMEN ANALYSIS MCS")
            //{
            //    tcode = "SEMALYS";
            //}
            //else if (tcode == "SEMEN ANALYSIS MCS")
            //{
            //    tcode = "SEMALYS";
            //}
            //else if (tcode == "SEMEN ANALYSIS MCS")
            //{
            //    tcode = "SEMALYS";
            //}
            else
            {
                tcode = tcode;
            }
            return tcode;
        }
    }
}

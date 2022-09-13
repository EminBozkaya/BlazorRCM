--
-- NOTE:
--
-- File paths need to be edited. Search for $$PATH$$ and
-- replace it with the path to the directory containing
-- the extracted data files.
--
--
-- PostgreSQL database dump
--

-- Dumped from database version 14.1
-- Dumped by pg_dump version 14.1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE "RCMblazorDb";
--
-- Name: RCMblazorDb; Type: DATABASE; Schema: -; Owner: -
--

CREATE DATABASE "RCMblazorDb" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Turkish_Turkey.1254';


\connect "RCMblazorDb"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: public; Type: SCHEMA; Schema: -; Owner: -
--

CREATE SCHEMA public;


--
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: -
--

COMMENT ON SCHEMA public IS 'standard public schema';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: AuthorityType; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."AuthorityType" (
    "Id" smallint NOT NULL,
    "Type" character varying
);


--
-- Name: AuthorityType_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."AuthorityType" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."AuthorityType_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Branch; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."Branch" (
    "Id" smallint NOT NULL,
    "Name" character varying NOT NULL,
    "Adress" character varying NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedTime" date DEFAULT CURRENT_DATE NOT NULL,
    "ModifiedTime" date
);


--
-- Name: BranchProductPrice; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."BranchProductPrice" (
    "BId" smallint NOT NULL,
    "PId" smallint NOT NULL,
    "BranchPrice" numeric NOT NULL,
    "VATpercent" numeric,
    "IsFavorite" boolean,
    "IsActive" boolean NOT NULL
);


--
-- Name: BranchSupplier; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."BranchSupplier" (
    "Id" integer NOT NULL,
    "BId" smallint NOT NULL,
    "SpId" integer NOT NULL,
    "CreatedBy" integer NOT NULL,
    "ModifiedBy" integer NOT NULL,
    "CreatedTime" date DEFAULT CURRENT_DATE NOT NULL,
    "ModifiedTime" date,
    "IsActive" boolean NOT NULL
);


--
-- Name: BranchSupplier_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."BranchSupplier" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."BranchSupplier_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Branch_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."Branch" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Branch_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: FirmType; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."FirmType" (
    "Id" smallint NOT NULL,
    "Name" character varying
);


--
-- Name: FirmType_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."FirmType" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."FirmType_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Product; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."Product" (
    "Id" smallint NOT NULL,
    "Name" character varying NOT NULL,
    "CatId" smallint NOT NULL,
    "Price" numeric(19,4),
    "VATpercent" numeric,
    "IsActive" boolean NOT NULL,
    "ColorCode" smallint,
    "MenuListId" smallint
);


--
-- Name: ProductCategory; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."ProductCategory" (
    "Id" smallint NOT NULL,
    "Name" character varying NOT NULL,
    "TopCatId" smallint,
    "IsActive" boolean NOT NULL
);


--
-- Name: ProductCategory_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."ProductCategory" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."ProductCategory_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: ProductMenuList; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."ProductMenuList" (
    "Id" smallint NOT NULL,
    "ListName" text,
    "IsActive" boolean NOT NULL
);


--
-- Name: ProductMenuList_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."ProductMenuList" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."ProductMenuList_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: ProductSaleNote; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."ProductSaleNote" (
    "Id" smallint NOT NULL,
    "Definition" text,
    "NoteCat" smallint
);


--
-- Name: ProductSaleNoteCategory; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."ProductSaleNoteCategory" (
    "Id" smallint NOT NULL,
    "NotCat" text
);


--
-- Name: ProductSaleNoteCategory_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."ProductSaleNoteCategory" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."ProductSaleNoteCategory_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: ProductSaleNote_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."ProductSaleNote" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."ProductSaleNote_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Product_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."Product" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Product_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Sale; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."Sale" (
    "Id" integer NOT NULL,
    "BId" smallint NOT NULL,
    "DateTime" timestamp without time zone DEFAULT now() NOT NULL,
    "UId" integer NOT NULL,
    "SaleNote" text,
    "IsEOD" boolean NOT NULL,
    "EOD" date,
    "IsActive" boolean NOT NULL,
    "TotalPrice" numeric DEFAULT 0.0 NOT NULL,
    "DailyBillOrder" integer NOT NULL,
    "DeletedBy" integer,
    "DeletedTime" timestamp without time zone,
    "IsModified" boolean,
    "ModifiedBy" integer,
    "ModifiedTime" timestamp without time zone,
    "STId" smallint
);


--
-- Name: SaleDetail; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."SaleDetail" (
    "Id" uuid DEFAULT public.uuid_generate_v4() NOT NULL,
    "SId" integer NOT NULL,
    "PId" smallint NOT NULL,
    "Price" numeric NOT NULL,
    "Portion" numeric NOT NULL,
    "Qty" smallint NOT NULL,
    "Total" numeric NOT NULL,
    "Note" text,
    "ModifiedBy" integer,
    "ModifiedTime" timestamp with time zone,
    "IsActive" boolean NOT NULL,
    "firstProductNote" text,
    "generalProductNote" text,
    "secondProductNote" text,
    "thirdProductNote" text,
    "BillOrder" smallint
);


--
-- Name: SaleType; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."SaleType" (
    "Id" smallint NOT NULL,
    "Type" character varying NOT NULL,
    "IsActive" boolean,
    "TopSTId" smallint
);


--
-- Name: SaleType_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."SaleType" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."SaleType_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Sale_DailyBillOrder_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."Sale" ALTER COLUMN "DailyBillOrder" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Sale_DailyBillOrder_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Sale_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."Sale" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Sale_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Supplier; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."Supplier" (
    "Id" integer NOT NULL,
    "CompanyName" character varying NOT NULL,
    "Adress" character varying,
    "CreatedBy" integer NOT NULL,
    "ModifiedBy" integer NOT NULL,
    "CreatedTime" date DEFAULT CURRENT_DATE NOT NULL,
    "ModifiedTime" date,
    "IsActive" boolean NOT NULL
);


--
-- Name: SupplierFirmType; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."SupplierFirmType" (
    "Id" integer NOT NULL,
    "SpId" integer NOT NULL,
    "FtId" smallint NOT NULL,
    "CreatedBy" integer NOT NULL,
    "ModifiedBy" integer NOT NULL,
    "CreatedTime" date DEFAULT CURRENT_DATE NOT NULL,
    "ModifiedTime" date,
    "IsActive" boolean NOT NULL
);


--
-- Name: SupplierFirmType_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."SupplierFirmType" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."SupplierFirmType_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Supplier_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."Supplier" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Supplier_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: User; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."User" (
    "Id" integer NOT NULL,
    "FirstName" character varying NOT NULL,
    "LastName" character varying NOT NULL,
    "UserName" character varying NOT NULL,
    "Phone" character(10) NOT NULL,
    "Email" character varying NOT NULL,
    "Password" character varying NOT NULL,
    "IsActive" boolean NOT NULL,
    "CreatedTime" date DEFAULT CURRENT_DATE NOT NULL,
    "ModifiedTime" date
);


--
-- Name: UserBranchAuthority; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."UserBranchAuthority" (
    "Id" integer NOT NULL,
    "UId" integer NOT NULL,
    "BId" smallint NOT NULL,
    "ATId" smallint NOT NULL,
    "IsActive" boolean NOT NULL
);


--
-- Name: UserBranchAuthority_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."UserBranchAuthority" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."UserBranchAuthority_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: User_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."User" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."User_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


--
-- Data for Name: AuthorityType; Type: TABLE DATA; Schema: public; Owner: -
--

\i $$PATH$$/3496.dat

--
-- Data for Name: Branch; Type: TABLE DATA; Schema: public; Owner: -
--

\i $$PATH$$/3498.dat

--
-- Data for Name: BranchProductPrice; Type: TABLE DATA; Schema: public; Owner: -
--

\i $$PATH$$/3515.dat

--
-- Data for Name: BranchSupplier; Type: TABLE DATA; Schema: public; Owner: -
--

\i $$PATH$$/3512.dat

--
-- Data for Name: FirmType; Type: TABLE DATA; Schema: public; Owner: -
--

\i $$PATH$$/3500.dat

--
-- Data for Name: Product; Type: TABLE DATA; Schema: public; Owner: -
--

\i $$PATH$$/3506.dat

--
-- Data for Name: ProductCategory; Type: TABLE DATA; Schema: public; Owner: -
--

\i $$PATH$$/3502.dat

--
-- Data for Name: ProductMenuList; Type: TABLE DATA; Schema: public; Owner: -
--

\i $$PATH$$/3520.dat

--
-- Data for Name: ProductSaleNote; Type: TABLE DATA; Schema: public; Owner: -
--

\i $$PATH$$/3522.dat

--
-- Data for Name: ProductSaleNoteCategory; Type: TABLE DATA; Schema: public; Owner: -
--

\i $$PATH$$/3524.dat

--
-- Data for Name: Sale; Type: TABLE DATA; Schema: public; Owner: -
--

\i $$PATH$$/3517.dat

--
-- Data for Name: SaleDetail; Type: TABLE DATA; Schema: public; Owner: -
--

\i $$PATH$$/3518.dat

--
-- Data for Name: SaleType; Type: TABLE DATA; Schema: public; Owner: -
--

\i $$PATH$$/3527.dat

--
-- Data for Name: Supplier; Type: TABLE DATA; Schema: public; Owner: -
--

\i $$PATH$$/3508.dat

--
-- Data for Name: SupplierFirmType; Type: TABLE DATA; Schema: public; Owner: -
--

\i $$PATH$$/3514.dat

--
-- Data for Name: User; Type: TABLE DATA; Schema: public; Owner: -
--

\i $$PATH$$/3504.dat

--
-- Data for Name: UserBranchAuthority; Type: TABLE DATA; Schema: public; Owner: -
--

\i $$PATH$$/3510.dat

--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: -
--

\i $$PATH$$/3494.dat

--
-- Name: AuthorityType_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."AuthorityType_Id_seq"', 8, true);


--
-- Name: BranchSupplier_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."BranchSupplier_Id_seq"', 1, false);


--
-- Name: Branch_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."Branch_Id_seq"', 6, true);


--
-- Name: FirmType_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."FirmType_Id_seq"', 1, false);


--
-- Name: ProductCategory_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."ProductCategory_Id_seq"', 29, true);


--
-- Name: ProductMenuList_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."ProductMenuList_Id_seq"', 4, true);


--
-- Name: ProductSaleNoteCategory_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."ProductSaleNoteCategory_Id_seq"', 6, true);


--
-- Name: ProductSaleNote_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."ProductSaleNote_Id_seq"', 38, true);


--
-- Name: Product_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."Product_Id_seq"', 59, true);


--
-- Name: SaleType_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."SaleType_Id_seq"', 6, true);


--
-- Name: Sale_DailyBillOrder_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."Sale_DailyBillOrder_seq"', 23, true);


--
-- Name: Sale_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."Sale_Id_seq"', 86, true);


--
-- Name: SupplierFirmType_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."SupplierFirmType_Id_seq"', 1, false);


--
-- Name: Supplier_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."Supplier_Id_seq"', 1, false);


--
-- Name: UserBranchAuthority_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."UserBranchAuthority_Id_seq"', 7, true);


--
-- Name: User_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."User_Id_seq"', 9, true);


--
-- Name: BranchProductPrice PK_BranchProductPrice; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."BranchProductPrice"
    ADD CONSTRAINT "PK_BranchProductPrice" PRIMARY KEY ("BId", "PId");


--
-- Name: ProductSaleNote PK_ProductSaleNote; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."ProductSaleNote"
    ADD CONSTRAINT "PK_ProductSaleNote" PRIMARY KEY ("Id");


--
-- Name: ProductSaleNoteCategory PK_ProductSaleNoteCategory; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."ProductSaleNoteCategory"
    ADD CONSTRAINT "PK_ProductSaleNoteCategory" PRIMARY KEY ("Id");


--
-- Name: Sale PK_Sale; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Sale"
    ADD CONSTRAINT "PK_Sale" PRIMARY KEY ("Id");


--
-- Name: SaleDetail PK_SaleDetail; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."SaleDetail"
    ADD CONSTRAINT "PK_SaleDetail" PRIMARY KEY ("Id");


--
-- Name: SaleType PK_SaleType; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."SaleType"
    ADD CONSTRAINT "PK_SaleType" PRIMARY KEY ("Id");


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: AuthorityType pk_AuthorityType_id; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."AuthorityType"
    ADD CONSTRAINT "pk_AuthorityType_id" PRIMARY KEY ("Id");


--
-- Name: BranchSupplier pk_BranchSupplier_id; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."BranchSupplier"
    ADD CONSTRAINT "pk_BranchSupplier_id" PRIMARY KEY ("Id");


--
-- Name: Branch pk_Branch_id; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Branch"
    ADD CONSTRAINT "pk_Branch_id" PRIMARY KEY ("Id");


--
-- Name: FirmType pk_FirmType_id; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."FirmType"
    ADD CONSTRAINT "pk_FirmType_id" PRIMARY KEY ("Id");


--
-- Name: ProductCategory pk_ProductCategory_id; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."ProductCategory"
    ADD CONSTRAINT "pk_ProductCategory_id" PRIMARY KEY ("Id");


--
-- Name: ProductMenuList pk_ProductMenuList_id; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."ProductMenuList"
    ADD CONSTRAINT "pk_ProductMenuList_id" PRIMARY KEY ("Id");


--
-- Name: Product pk_Product_id; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Product"
    ADD CONSTRAINT "pk_Product_id" PRIMARY KEY ("Id");


--
-- Name: SupplierFirmType pk_SupplierFirmType_id; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."SupplierFirmType"
    ADD CONSTRAINT "pk_SupplierFirmType_id" PRIMARY KEY ("Id");


--
-- Name: Supplier pk_Supplier_id; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Supplier"
    ADD CONSTRAINT "pk_Supplier_id" PRIMARY KEY ("Id");


--
-- Name: UserBranchAuthority pk_UserBranchAuthority_id; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."UserBranchAuthority"
    ADD CONSTRAINT "pk_UserBranchAuthority_id" PRIMARY KEY ("Id");


--
-- Name: User pk_User_id; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "pk_User_id" PRIMARY KEY ("Id");


--
-- Name: IX_BranchProductPrice_PId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_BranchProductPrice_PId" ON public."BranchProductPrice" USING btree ("PId");


--
-- Name: IX_BranchSupplier_BId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_BranchSupplier_BId" ON public."BranchSupplier" USING btree ("BId");


--
-- Name: IX_BranchSupplier_CreatedBy; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_BranchSupplier_CreatedBy" ON public."BranchSupplier" USING btree ("CreatedBy");


--
-- Name: IX_BranchSupplier_ModifiedBy; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_BranchSupplier_ModifiedBy" ON public."BranchSupplier" USING btree ("ModifiedBy");


--
-- Name: IX_BranchSupplier_SpId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_BranchSupplier_SpId" ON public."BranchSupplier" USING btree ("SpId");


--
-- Name: IX_ProductCategory_TopCatId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_ProductCategory_TopCatId" ON public."ProductCategory" USING btree ("TopCatId");


--
-- Name: IX_ProductSaleNote_NoteCat; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_ProductSaleNote_NoteCat" ON public."ProductSaleNote" USING btree ("NoteCat");


--
-- Name: IX_Product_CatId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_Product_CatId" ON public."Product" USING btree ("CatId");


--
-- Name: IX_Product_MenuListId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_Product_MenuListId" ON public."Product" USING btree ("MenuListId");


--
-- Name: IX_SaleDetail_ModifiedBy; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_SaleDetail_ModifiedBy" ON public."SaleDetail" USING btree ("ModifiedBy");


--
-- Name: IX_SaleDetail_PId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_SaleDetail_PId" ON public."SaleDetail" USING btree ("PId");


--
-- Name: IX_SaleDetail_SId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_SaleDetail_SId" ON public."SaleDetail" USING btree ("SId");


--
-- Name: IX_SaleType_TopSTId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_SaleType_TopSTId" ON public."SaleType" USING btree ("TopSTId");


--
-- Name: IX_Sale_BId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_Sale_BId" ON public."Sale" USING btree ("BId");


--
-- Name: IX_Sale_DeletedBy; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_Sale_DeletedBy" ON public."Sale" USING btree ("DeletedBy");


--
-- Name: IX_Sale_STId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_Sale_STId" ON public."Sale" USING btree ("STId");


--
-- Name: IX_SupplierFirmType_CreatedBy; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_SupplierFirmType_CreatedBy" ON public."SupplierFirmType" USING btree ("CreatedBy");


--
-- Name: IX_SupplierFirmType_FtId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_SupplierFirmType_FtId" ON public."SupplierFirmType" USING btree ("FtId");


--
-- Name: IX_SupplierFirmType_ModifiedBy; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_SupplierFirmType_ModifiedBy" ON public."SupplierFirmType" USING btree ("ModifiedBy");


--
-- Name: IX_SupplierFirmType_SpId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_SupplierFirmType_SpId" ON public."SupplierFirmType" USING btree ("SpId");


--
-- Name: IX_Supplier_CreatedBy; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_Supplier_CreatedBy" ON public."Supplier" USING btree ("CreatedBy");


--
-- Name: IX_Supplier_ModifiedBy; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_Supplier_ModifiedBy" ON public."Supplier" USING btree ("ModifiedBy");


--
-- Name: IX_UserBranchAuthority_ATId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_UserBranchAuthority_ATId" ON public."UserBranchAuthority" USING btree ("ATId");


--
-- Name: IX_UserBranchAuthority_BId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_UserBranchAuthority_BId" ON public."UserBranchAuthority" USING btree ("BId");


--
-- Name: IX_UserBranchAuthority_UId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_UserBranchAuthority_UId" ON public."UserBranchAuthority" USING btree ("UId");


--
-- Name: BranchProductPrice FK_BranchProductPrice_Branch_BId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."BranchProductPrice"
    ADD CONSTRAINT "FK_BranchProductPrice_Branch_BId" FOREIGN KEY ("BId") REFERENCES public."Branch"("Id") ON DELETE CASCADE;


--
-- Name: BranchProductPrice FK_BranchProductPrice_Product_PId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."BranchProductPrice"
    ADD CONSTRAINT "FK_BranchProductPrice_Product_PId" FOREIGN KEY ("PId") REFERENCES public."Product"("Id") ON DELETE CASCADE;


--
-- Name: BranchSupplier FK_BranchSupplier_Branch_BId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."BranchSupplier"
    ADD CONSTRAINT "FK_BranchSupplier_Branch_BId" FOREIGN KEY ("BId") REFERENCES public."Branch"("Id") ON DELETE CASCADE;


--
-- Name: BranchSupplier FK_BranchSupplier_Supplier_SpId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."BranchSupplier"
    ADD CONSTRAINT "FK_BranchSupplier_Supplier_SpId" FOREIGN KEY ("SpId") REFERENCES public."Supplier"("Id") ON DELETE CASCADE;


--
-- Name: BranchSupplier FK_BranchSupplier_User_CreatedBy; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."BranchSupplier"
    ADD CONSTRAINT "FK_BranchSupplier_User_CreatedBy" FOREIGN KEY ("CreatedBy") REFERENCES public."User"("Id") ON DELETE CASCADE;


--
-- Name: BranchSupplier FK_BranchSupplier_User_ModifiedBy; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."BranchSupplier"
    ADD CONSTRAINT "FK_BranchSupplier_User_ModifiedBy" FOREIGN KEY ("ModifiedBy") REFERENCES public."User"("Id") ON DELETE CASCADE;


--
-- Name: ProductSaleNote FK_ProductSaleNote_ProductSaleNoteCategory_NoteCat; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."ProductSaleNote"
    ADD CONSTRAINT "FK_ProductSaleNote_ProductSaleNoteCategory_NoteCat" FOREIGN KEY ("NoteCat") REFERENCES public."ProductSaleNoteCategory"("Id") ON DELETE CASCADE;


--
-- Name: Product FK_Product_ProductCategory_CatId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Product"
    ADD CONSTRAINT "FK_Product_ProductCategory_CatId" FOREIGN KEY ("CatId") REFERENCES public."ProductCategory"("Id") ON DELETE CASCADE;


--
-- Name: Product FK_Product_ProductMenuList_MenuListId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Product"
    ADD CONSTRAINT "FK_Product_ProductMenuList_MenuListId" FOREIGN KEY ("MenuListId") REFERENCES public."ProductMenuList"("Id") ON DELETE CASCADE;


--
-- Name: SaleDetail FK_SaleDetail_Product_PId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."SaleDetail"
    ADD CONSTRAINT "FK_SaleDetail_Product_PId" FOREIGN KEY ("PId") REFERENCES public."Product"("Id") ON DELETE CASCADE;


--
-- Name: SaleDetail FK_SaleDetail_Sale_SId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."SaleDetail"
    ADD CONSTRAINT "FK_SaleDetail_Sale_SId" FOREIGN KEY ("SId") REFERENCES public."Sale"("Id") ON DELETE CASCADE;


--
-- Name: SaleDetail FK_SaleDetail_User_ModifiedBy; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."SaleDetail"
    ADD CONSTRAINT "FK_SaleDetail_User_ModifiedBy" FOREIGN KEY ("ModifiedBy") REFERENCES public."User"("Id") ON DELETE CASCADE;


--
-- Name: Sale FK_Sale_Branch_BId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Sale"
    ADD CONSTRAINT "FK_Sale_Branch_BId" FOREIGN KEY ("BId") REFERENCES public."Branch"("Id") ON DELETE CASCADE;


--
-- Name: Sale FK_Sale_SaleType_STId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Sale"
    ADD CONSTRAINT "FK_Sale_SaleType_STId" FOREIGN KEY ("STId") REFERENCES public."SaleType"("Id") ON DELETE CASCADE;


--
-- Name: Sale FK_Sale_User_DeletedBy; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Sale"
    ADD CONSTRAINT "FK_Sale_User_DeletedBy" FOREIGN KEY ("DeletedBy") REFERENCES public."User"("Id") ON DELETE CASCADE;


--
-- Name: Sale FK_Sale_User_ModifiedBy; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Sale"
    ADD CONSTRAINT "FK_Sale_User_ModifiedBy" FOREIGN KEY ("ModifiedBy") REFERENCES public."User"("Id") ON DELETE CASCADE;


--
-- Name: Sale FK_Sale_User_UId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Sale"
    ADD CONSTRAINT "FK_Sale_User_UId" FOREIGN KEY ("UId") REFERENCES public."User"("Id") ON DELETE CASCADE;


--
-- Name: ProductCategory FK_SubProductCategories_TopProduct_TopCatId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."ProductCategory"
    ADD CONSTRAINT "FK_SubProductCategories_TopProduct_TopCatId" FOREIGN KEY ("TopCatId") REFERENCES public."ProductCategory"("Id") ON DELETE CASCADE;


--
-- Name: SaleType FK_SubSubSaleTypes_TopSaleType_TopSTId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."SaleType"
    ADD CONSTRAINT "FK_SubSubSaleTypes_TopSaleType_TopSTId" FOREIGN KEY ("TopSTId") REFERENCES public."SaleType"("Id") ON DELETE CASCADE;


--
-- Name: SupplierFirmType FK_SupplierFirmType_FirmType_FtId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."SupplierFirmType"
    ADD CONSTRAINT "FK_SupplierFirmType_FirmType_FtId" FOREIGN KEY ("FtId") REFERENCES public."FirmType"("Id") ON DELETE CASCADE;


--
-- Name: SupplierFirmType FK_SupplierFirmType_Supplier_SpId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."SupplierFirmType"
    ADD CONSTRAINT "FK_SupplierFirmType_Supplier_SpId" FOREIGN KEY ("SpId") REFERENCES public."Supplier"("Id") ON DELETE CASCADE;


--
-- Name: SupplierFirmType FK_SupplierFirmType_User_CreatedBy; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."SupplierFirmType"
    ADD CONSTRAINT "FK_SupplierFirmType_User_CreatedBy" FOREIGN KEY ("CreatedBy") REFERENCES public."User"("Id") ON DELETE CASCADE;


--
-- Name: SupplierFirmType FK_SupplierFirmType_User_ModifiedBy; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."SupplierFirmType"
    ADD CONSTRAINT "FK_SupplierFirmType_User_ModifiedBy" FOREIGN KEY ("ModifiedBy") REFERENCES public."User"("Id") ON DELETE CASCADE;


--
-- Name: Supplier FK_Supplier_User_CreatedBy; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Supplier"
    ADD CONSTRAINT "FK_Supplier_User_CreatedBy" FOREIGN KEY ("CreatedBy") REFERENCES public."User"("Id") ON DELETE CASCADE;


--
-- Name: Supplier FK_Supplier_User_ModifiedBy; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Supplier"
    ADD CONSTRAINT "FK_Supplier_User_ModifiedBy" FOREIGN KEY ("ModifiedBy") REFERENCES public."User"("Id") ON DELETE CASCADE;


--
-- Name: UserBranchAuthority FK_UserBranchAuthoritiy_AuthorityType_ATId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."UserBranchAuthority"
    ADD CONSTRAINT "FK_UserBranchAuthoritiy_AuthorityType_ATId" FOREIGN KEY ("ATId") REFERENCES public."AuthorityType"("Id") ON DELETE CASCADE;


--
-- Name: UserBranchAuthority FK_UserBranchAuthoritiy_Branch_BId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."UserBranchAuthority"
    ADD CONSTRAINT "FK_UserBranchAuthoritiy_Branch_BId" FOREIGN KEY ("BId") REFERENCES public."Branch"("Id") ON DELETE CASCADE;


--
-- Name: UserBranchAuthority FK_UserBranchAuthoritiy_User_UId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."UserBranchAuthority"
    ADD CONSTRAINT "FK_UserBranchAuthoritiy_User_UId" FOREIGN KEY ("UId") REFERENCES public."User"("Id") ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--


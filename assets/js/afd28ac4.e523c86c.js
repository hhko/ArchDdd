"use strict";(self.webpackChunkdocs=self.webpackChunkdocs||[]).push([[704],{3695:(e,n,r)=>{r.r(n),r.d(n,{assets:()=>s,contentTitle:()=>d,default:()=>g,frontMatter:()=>i,metadata:()=>t,toc:()=>a});var o=r(4848),l=r(8453);const i={},d="\uc77c\ub300\uc77c \uad00\uacc4",t={id:"design/efcore/one-to-one/README",title:"\uc77c\ub300\uc77c \uad00\uacc4",description:"- One-to-one relationships",source:"@site/docs/03-design/07-efcore/02-one-to-one/README.md",sourceDirName:"03-design/07-efcore/02-one-to-one",slug:"/design/efcore/one-to-one/",permalink:"/ArchDdd/docs/design/efcore/one-to-one/",draft:!1,unlisted:!1,editUrl:"https://github.com/hhko/ArchDdd/tree/main/docs/docs/03-design/07-efcore/02-one-to-one/README.md",tags:[],version:"current",frontMatter:{},sidebar:"tutorialSidebar",previous:{title:"EFCore",permalink:"/ArchDdd/docs/category/efcore"},next:{title:"EFCore",permalink:"/ArchDdd/docs/design/efcore/"}},s={},a=[{value:"Required one-to-one",id:"required-one-to-one",level:2},{value:"Required one-to-one with primary key to primary key relationship",id:"required-one-to-one-with-primary-key-to-primary-key-relationship",level:2},{value:"\uc554\uc2dc\uc801",id:"\uc554\uc2dc\uc801",level:3},{value:"Required one-to-one with shadow foreign key",id:"required-one-to-one-with-shadow-foreign-key",level:2}];function c(e){const n={a:"a",code:"code",h1:"h1",h2:"h2",h3:"h3",li:"li",pre:"pre",ul:"ul",...(0,l.R)(),...e.components};return(0,o.jsxs)(o.Fragment,{children:[(0,o.jsx)(n.h1,{id:"\uc77c\ub300\uc77c-\uad00\uacc4",children:"\uc77c\ub300\uc77c \uad00\uacc4"}),"\n",(0,o.jsxs)(n.ul,{children:["\n",(0,o.jsx)(n.li,{children:(0,o.jsx)(n.a,{href:"https://learn.microsoft.com/en-us/ef/core/modeling/relationships/one-to-one",children:"One-to-one relationships"})}),"\n"]}),"\n",(0,o.jsx)(n.pre,{children:(0,o.jsx)(n.code,{className:"language-sql",children:"SELECT sqlite_version();\n"})}),"\n",(0,o.jsx)(n.h2,{id:"required-one-to-one",children:"Required one-to-one"}),"\n",(0,o.jsx)(n.pre,{children:(0,o.jsx)(n.code,{className:"language-sql",children:'CREATE TABLE "Blogs"(\r\n  "Id" INTEGER NOT NULL CONSTRAINT "PK_Blogs" PRIMARY KEY AUTOINCREMENT\r\n)\r\n\r\nCREATE TABLE "BlogHeaders"(\r\n  "Id" INTEGER NOT NULL CONSTRAINT "PK_BlogHeaders" PRIMARY KEY AUTOINCREMENT,\r\n  "BlogId" INTEGER NOT NULL,\r\n  CONSTRAINT "FK_BlogHeaders_Blogs_BlogId" FOREIGN KEY("BlogId") REFERENCES "Blogs"("Id") ON DELETE CASCADE\r\n)\n'})}),"\n",(0,o.jsx)(n.pre,{children:(0,o.jsx)(n.code,{className:"language-cs",children:"protected override void OnModelCreating(ModelBuilder builder)\r\n{\r\n  builder.Entity<Blog>()\r\n    .HasOne(blog => blog.Header)\r\n    .WithOne(blogHeader => blogHeader.Blog)\r\n    .HasForeignKey<BlogHeader>(blogHeader => blogHeader.BlogId)\r\n    .IsRequired();\r\n}\n"})}),"\n",(0,o.jsx)(n.pre,{children:(0,o.jsx)(n.code,{className:"language-cs",children:"// Principal (parent)\r\npublic class Blog\r\n{\r\n  public int Id { get; set; }\r\n  public BlogHeader? Header { get; set; } // Reference navigation to dependent\r\n}\r\n\r\n// Dependent (child)\r\npublic class BlogHeader\r\n{\r\n  public int Id { get; set; }\r\n  public int BlogId { get; set; } // Required foreign key property\r\n  public Blog Blog { get; set; } = null!; // Required reference navigation to principal\r\n}\n"})}),"\n",(0,o.jsx)(n.h2,{id:"required-one-to-one-with-primary-key-to-primary-key-relationship",children:"Required one-to-one with primary key to primary key relationship"}),"\n",(0,o.jsx)(n.h3,{id:"\uc554\uc2dc\uc801",children:"\uc554\uc2dc\uc801"}),"\n",(0,o.jsx)(n.pre,{children:(0,o.jsx)(n.code,{className:"language-sql",children:'CREATE TABLE "Blogs"(\r\n      "Id" INTEGER NOT NULL CONSTRAINT "PK_Blogs" PRIMARY KEY AUTOINCREMENT\r\n)\r\n\r\nCREATE TABLE "BlogHeaders" (\r\n  "Id" INTEGER NOT NULL CONSTRAINT "PK_BlogHeaders" PRIMARY KEY,\r\n  CONSTRAINT "FK_BlogHeaders_Blogs_Id" FOREIGN KEY("Id") REFERENCES "Blogs" ("Id") ON DELETE CASCADE\r\n)\n'})}),"\n",(0,o.jsx)(n.pre,{children:(0,o.jsx)(n.code,{className:"language-cs",children:"protected override void OnModelCreating(ModelBuilder builder)\r\n{\r\n  builder.Entity<Blog>()\r\n    .HasOne(blog => blog.Header)\r\n    .WithOne(blogHeader => blogHeader.Blog)\r\n    .HasForeignKey<BlogHeader>();\r\n}\n"})}),"\n",(0,o.jsx)(n.pre,{children:(0,o.jsx)(n.code,{className:"language-cs",children:"// Principal (parent)\r\npublic class Blog\r\n{\r\n  public int Id { get; set; }\r\n  public BlogHeader? Header { get; set; } // Reference navigation to dependent\r\n}\r\n\r\n// Dependent (child)\r\npublic class BlogHeader\r\n{\r\n  public int Id { get; set; }\r\n  public Blog Blog { get; set; } = null!; // Required reference navigation to principal\r\n}\n"})}),"\n",(0,o.jsx)(n.h2,{id:"required-one-to-one-with-shadow-foreign-key",children:"Required one-to-one with shadow foreign key"}),"\n",(0,o.jsx)(n.pre,{children:(0,o.jsx)(n.code,{className:"language-sql",children:'CREATE TABLE "Blogs"(\r\n  "Id" INTEGER NOT NULL CONSTRAINT "PK_Blogs" PRIMARY KEY AUTOINCREMENT\r\n)\r\n\r\nCREATE TABLE "BlogHeaders" (\r\n  "Id" INTEGER NOT NULL CONSTRAINT "PK_BlogHeaders" PRIMARY KEY AUTOINCREMENT,\r\n  "BlogId" INTEGER NOT NULL,\r\n  CONSTRAINT "FK_BlogHeaders_Blogs_BlogId" FOREIGN KEY ("BlogId") REFERENCES "Blogs" ("Id") ON DELETE CASCADE\r\n)\n'})}),"\n",(0,o.jsx)(n.pre,{children:(0,o.jsx)(n.code,{className:"language-cs",children:"protected override void OnModelCreating(ModelBuilder builder)\r\n{\r\n  builder.Entity<Blog>()\r\n    .HasOne(blog => blog.Header)\r\n    .WithOne(blogHeader => blogHeader.Blog)\r\n    .HasForeignKey<BlogHeader>(blogHeader => blogHeader.Id)   // \ub370\uc774\ud130\ubca0\uc774\uc2a4 \uc804\uc6a9 \ubcc0\uc218\r\n    .IsRequired();\r\n}\n"})}),"\n",(0,o.jsx)(n.pre,{children:(0,o.jsx)(n.code,{className:"language-cs",children:"// Principal (parent)\r\npublic class Blog\r\n{\r\n  public int Id { get; set; }\r\n  public BlogHeader? Header { get; set; } // Reference navigation to dependent\r\n}\r\n\r\n// Dependent (child)\r\npublic class BlogHeader\r\n{\r\n  public int Id { get; set; }\r\n  public Blog Blog { get; set; } = null!; // Required reference navigation to principal\r\n}\n"})})]})}function g(e={}){const{wrapper:n}={...(0,l.R)(),...e.components};return n?(0,o.jsx)(n,{...e,children:(0,o.jsx)(c,{...e})}):c(e)}},8453:(e,n,r)=>{r.d(n,{R:()=>d,x:()=>t});var o=r(6540);const l={},i=o.createContext(l);function d(e){const n=o.useContext(i);return o.useMemo((function(){return"function"==typeof e?e(n):{...n,...e}}),[n,e])}function t(e){let n;return n=e.disableParentContext?"function"==typeof e.components?e.components(l):e.components||l:d(e.components),o.createElement(i.Provider,{value:n},e.children)}}}]);
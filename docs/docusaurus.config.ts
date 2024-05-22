import {themes as prismThemes} from 'prism-react-renderer';
import type {Config} from '@docusaurus/types';
import type * as Preset from '@docusaurus/preset-classic';

const config: Config = {
  title: 'ArchDDD',
  tagline: '클린 아키텍처와 도메인 주도 설계',
  favicon: 'img/favicon.ico',

  // Set the production url of your site here
  url: 'https://your-docusaurus-site.example.com',
  // Set the /<baseUrl>/ pathname under which your site is served
  // For GitHub pages deployment, it is often '/<projectName>/'
  baseUrl: '/archddd/',

  // GitHub pages deployment config.
  // If you aren't using GitHub pages, you don't need these.
  organizationName: 'hhko', // Usually your GitHub org/user name.
  projectName: 'archddd', // Usually your repo name.

  onBrokenLinks: 'throw',
  onBrokenMarkdownLinks: 'warn',

  // Even if you don't use internationalization, you can use this field to set
  // useful metadata like html lang. For example, if your site is Chinese, you
  // may want to replace "en" with "zh-Hans".
  i18n: {
    defaultLocale: 'en',
    locales: ['en'],
  },

  presets: [
    [
      'classic',
      {
        docs: {
          sidebarPath: './sidebars.ts',
          // Please change this to your repo.
          // Remove this to remove the "edit this page" links.
          editUrl:
            'https://github.com/hhko/archddd/tree/main/docs/',
        },
        // blog: {
        //   blogSidebarTitle: 'All posts',
        //   blogSidebarCount: 'ALL',
        //   // Please change this to your repo.
        //   // Remove this to remove the "edit this page" links.
        //   editUrl:
        //     'https://github.com/hhko/archddd/tree/main/docs/',
        // },
        theme: {
          customCss: './src/css/custom.css',
        },
      } satisfies Preset.Options,
    ],
  ],

  themeConfig: {
    // Replace with your project's social card
    image: 'img/docusaurus-social-card.jpg',
    navbar: {
      title: 'ArchDDD',
      logo: {
        alt: 'My Site Logo',
        src: 'img/logo.svg',
      },
      items: [
        {
          type: 'docSidebar',
          sidebarId: 'tutorialSidebar',
          position: 'left',
          label: 'Tutorial',
        },
        // {
        //   to: '/blog',
        //   label: 'Todo',
        //   position: 'left'
        // },
        {
          href: 'https://github.com/hhko/archddd',
          label: 'GitHub',
          position: 'right',
        },
        // {
        //   type: 'search',
        //   position: 'right',
        // },
      ],
    },
    footer: {
      // links: [
      //   {
      //     title: 'Community',
      //     items: [
      //       {
      //         label: 'GitHub',
      //         href: 'https://github.com/hhko/archddd',
      //       },
      //     ],
      //   },
      // ],
      style: 'dark',
      copyright: `배움은 <b>설렘</b>이다. 배움은 <b>겸손</b>이다. 배움은 <b>이타심</b>이다.`,
    },
    prism: {
      theme: prismThemes.dracula,
      darkTheme: prismThemes.dracula,
      additionalLanguages: ['powershell', 'csharp'],
    },
  } satisfies Preset.ThemeConfig,
};

export default config;

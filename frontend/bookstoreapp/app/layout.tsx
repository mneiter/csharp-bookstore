import Layout, { Header, Content, Footer } from "antd/es/layout/layout"
import "./globals.css";
import { Menu } from "antd";
import Link from "next/link";

const items = [
  { key: "home", label: <Link href={"/"}>Home</Link> }
  , { key: "books", label: <Link href={"/books"}>Books</Link> }
];

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body>
        <Layout style={{ minHight: "100vh" }}>
          <Header>
            <Menu
              theme="dark"
              mode="horizontal"
              items={items}
              style={{ flex: 1, minWidth: 0 }} />
          </Header>
          <Content style={{ padding: "0 48" }}>{children}</Content>
          <Footer style={{ textAlign: "center" }}>
            The bookstore was created in 2024
          </Footer>
        </Layout>
      </body>
    </html >
  );
}

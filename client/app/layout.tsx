import Providers from "./providers";
import "./globals.css";
import Navbar from "../components/navbar/Navbar";
import Sidebar from "../components/sidebar/Sidebar";
import PageContainer from "../components/PageContainer";

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html>
      <head />
      <body>
        <Providers>
          <Navbar></Navbar>
          <Sidebar></Sidebar>
          <PageContainer>{children}</PageContainer>
        </Providers>
      </body>
    </html>
  );
}

import Providers from "./providers";
import "./globals.css";
import Navbar from "../components/navbar/Navbar";

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  console.log("denne her skal ikke logges i nettleser");
  return (
    <html>
      <head />
      <body>
        <Navbar></Navbar>
        <Providers>{children}</Providers>
      </body>
    </html>
  );
}

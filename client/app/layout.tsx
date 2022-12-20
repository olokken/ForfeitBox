import Link from "next/link";
import Providers from "./providers";
import "./globals.css";

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
        <nav>
          <Link href="/feed">Feed</Link>
          <Link href="/">Home</Link>
        </nav>
        <Providers>{children}</Providers>
      </body>
    </html>
  );
}

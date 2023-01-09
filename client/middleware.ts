import { NextResponse } from "next/server";
import type { NextRequest } from "next/server";
import { withAuth } from "next-auth/middleware";
import { getToken, JWT } from "next-auth/jwt";

export default withAuth(async function middleware(req: NextRequest) {
  const token: JWT | null = await getToken({ req });

  const requestHeaders = new Headers(req.headers);
  if (token) {
    let accessToken: string = token.accessToken;
    requestHeaders.set("authentication", `bearer ${accessToken}`);
  }

  // You can also set request headers in NextResponse.rewrite
  const response = NextResponse.next({
    request: {
      // New request headers
      headers: requestHeaders,
    },
  });

  // Set a new response header `x-hello-from-middleware2`
  return response;
});

export const config = { matcher: ["/:path*"] };

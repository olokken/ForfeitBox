import React from "react";
import Link from "next/link";
import { MinimalBox } from "../../../models/Box";

type BoxCardProps = {
  box: MinimalBox;
};

function BoxCard({ box }: BoxCardProps) {
  return (
    <Link className="" href={`/box/${box.boxId}`}>
      <button className="custom-btn w-full rounded-full">{box.name}</button>
    </Link>
  );
}

export default BoxCard;

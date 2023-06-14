import React from "react";
import styles from "./Navigation.module.css";
import { Link } from "react-router-dom";

export default function Navigation() {
  return (
    <div className={styles.nav}>
      <Link to={"/"} className={styles.title}>
        CKS MANAGER
      </Link>
    </div>
  );
}

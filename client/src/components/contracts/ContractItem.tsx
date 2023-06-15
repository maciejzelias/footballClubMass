import React, { useState } from "react";
import styles from "./ContractItem.module.css";
import { Contract } from "./ContractList";
import { useFormik } from "formik";
import * as yup from "yup";
import { useNavigate } from "react-router-dom";
import { ClipLoader } from "react-spinners";

const validationSchema = yup.object({
  content: yup.string(),
  // content: yup.string().required("Content is required."),
});

const PlayerItem: React.FC<{ contract: Contract }> = ({ contract }) => {
  const navigate = useNavigate();
  const [isNewPageMode, setPageMode] = useState(false);

  const [error, setError] = useState("");

  const formik = useFormik({
    initialValues: {
      content: "",
    },
    validationSchema: validationSchema,
    onSubmit: async (values) => {
      try {
        const response = await fetch(`http://localhost:5049/contracts`, {
          method: "POST",
          body: JSON.stringify({
            contractId: contract.id,
            pageContent: values.content,
          }),
          headers: { "Content-Type": "application/json" },
        });

        if (response.ok) {
          navigate(0);
        } else {
          const errorMessage = await response.text();
          setError(errorMessage);
        }
      } catch (err: unknown) {
        setError("error");
      }
    },
  });

  const reloadPageHandler = () => {
    navigate(0);
  };

  return (
    <div className={styles.contract}>
      <p>
        Contract {contract.playerName} {contract.playerSurname}
      </p>
      <p>End date: {contract.endDate.substring(0, 10)}</p>
      <p>Salary: {contract.salary}</p>
      {contract.pages.map((page) => (
        <p key={page.pageNumber}>
          Page {page.pageNumber}: {page.content}
        </p>
      ))}
      {!isNewPageMode && (
        <button
          className={styles.newPageButton}
          onClick={() => setPageMode(true)}>
          Add new page
        </button>
      )}
      {isNewPageMode && (
        <div className={styles.newPageContainer}>
          <p className={styles.newPageTitle}>Adding new page</p>
          {formik.isSubmitting ? (
            <div className={styles.loader}>
              <ClipLoader />
            </div>
          ) : !error ? (
            <form className={styles.form} onSubmit={formik.handleSubmit}>
              <div>
                <label htmlFor="content">Content:</label>
                <input
                  type="text"
                  id="content"
                  name="content"
                  value={formik.values.content}
                  onChange={formik.handleChange}
                  onBlur={formik.handleBlur}
                />
                {formik.touched.content && formik.errors.content ? (
                  <div className={styles.errors}>{formik.errors.content}</div>
                ) : null}
              </div>
              <div className={styles.buttonsWrapper}>
                <button className={styles.submitButton} type="submit">
                  Submit
                </button>
                <button
                  className={styles.cancelButton}
                  onClick={() => {
                    setPageMode(false);
                  }}>
                  Cancel
                </button>
              </div>
            </form>
          ) : (
            <div className={styles.form}>
              {error}
              <button
                className={styles.submitButton}
                onClick={reloadPageHandler}>
                Retry
              </button>
            </div>
          )}
        </div>
      )}
    </div>
  );
};

export default PlayerItem;

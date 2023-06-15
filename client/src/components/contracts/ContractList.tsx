import React from "react";
import { useParams } from "react-router-dom";
import useFetchList from "../../hooks/useFetchList";
import ContractItem from "./ContractItem";
import styles from "./ContractList.module.css";

interface ContractPage {
  content: string;
  pageNumber: number;
}

export interface Contract {
  id: number;
  endDate: string;
  salary: number;
  pages: ContractPage[];
  playerName: string;
  playerSurname: string;
}

export default function ContractList() {
  const { playerId } = useParams();

  const {
    list: contracts,
    error,
    isLoading,
  } = useFetchList<Contract>(`http://localhost:5049/contracts/${playerId}`);


  let content = <p className={styles.title}> Pick a contract </p>;

  if (error) {
    content = <p> {error}</p>;
  }

  if (isLoading) {
    content = <p>Loading data..</p>;
  }

  console.log(contracts);

  return (
    <div className={styles.mainContent}>
      {content}
      {contracts.map((contract) => (
        <ContractItem contract={contract} key={contract.id} />
      ))}
    </div>
  );
}

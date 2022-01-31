import React, { useEffect, useState } from "react";
import SneakerCard from "./sneakerCard";
import { getAllSneakers } from '../../modules/sneakerManager';

export const SneakerList = () => {
    const [sneakers, setSneakers] = useState([]);

    const getSneakers = () => {
        return getAllSneakers().then(sneakers => {
            setSneakers(sneakers)
        });
    };

    useEffect(() => {
        getSneakers();
    }, []);

    return (
        <> <div>
            <div>{sneakers.map(sneaker => <SneakerCard key={sneaker.id} sneaker={sneaker} />)}</div>
        </div>
        </>
    )
}
export default SneakerList;



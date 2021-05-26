import axios from 'axios';
import React, { useState, useEffect } from 'react';
import TableRow from '../Components/TableRow';

const Home = () => {

    const [scoops, setScoops] = useState([]);
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        const getScoops = async () => {
            const { data } = await axios.get('/api/scoops/getscoops');
            setScoops(data);
            setIsLoading(false);
        }
        getScoops();
    })
    return (
        <table className='table table-hover table-bordered table-striped'>
            <thead>
                <tr>

                    <td>Title</td>
                    <td style={{ width: "20%" }}>Image</td>
                    <td>Text</td>
                    <td>Comments</td>
                </tr>
            </thead>
            {isLoading && <h1>Scraping data - DW it's legal.... This may take a while...</h1>}
            <tbody>
          
                {scoops && scoops.map((s, idx) => <TableRow key={idx} scoop={s} />)}
            </tbody>
        </table>
    )
}
export default Home;
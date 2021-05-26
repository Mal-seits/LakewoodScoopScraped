import React from 'react';

const TableRow = ({ scoop }) => {
    const { title, imageURL, text, comments, link } = scoop;

    return(
        <tr>

            <td>
                <a href={link} target="_blank"> 
                    {title}
                </a>
            </td>
            <td>
                
               {imageURL !== null ? <img width="100" height="100" src={imageURL} />  : "No Picture Provided"}
            </td>
            <td>
                {text}
            </td>
            <td>
                {comments}
            </td>
        </tr>
    )
}
export default TableRow
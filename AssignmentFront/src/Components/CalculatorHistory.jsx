import {useEffect} from 'react'
import {Paper, Table, TableHead, TableRow, TableCell, TableContainer, TableBody, Typography, Stack, Divider} from '@mui/material'

export default function CalculatorHistory({history, error})
{
    useEffect(()=>{
        
    }, [history])

    return (
        <Stack component={Paper}  >
            <Typography sx={{paddingY: '1em'}} alignSelf="center">Results History</Typography>
            <Divider/>
            <TableContainer sx={{ maxHeight: 460 }}>
              <Table stickyHeader>
                <TableHead>
                  <TableRow>
                    <TableCell>Mass</TableCell>
                    <TableCell>Velocity</TableCell>
                    <TableCell>Energy</TableCell>
                    <TableCell>Comment</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody sx={{ width: '100%', overflow: 'hidden' }}>
                  {error ?
                    <ErrorRow error={error}/> :
                    history.map((row, index) => (
                      <CalculationResultItem key={`result-${index}`} calculationResult={row}/>
                    ))
                  }
                </TableBody>
              </Table>
            </TableContainer>
        </Stack>
    
    )
}

function ErrorRow({error})
{
  return (
    <TableRow>
      <TableCell><Typography color='red' padding={1}>{error}</Typography></TableCell>
    </TableRow>
  )
}

function CalculationResultItem({calculationResult})
{
    return (
        <TableRow
        sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
        >
            <TableCell>{calculationResult.mass}</TableCell>
            <TableCell>{calculationResult.velocity}</TableCell>
            <TableCell>{calculationResult.energy}</TableCell>
            <TableCell>{calculationResult.comment}</TableCell>
      </TableRow>
    )
}


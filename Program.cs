using System;

namespace percepteron_lab_1__by_Vahid_Hajiyev
{
    class Program
    {

        float y;
        float v;
        float[] weights = new float[2];
        float learningRate = 0.2F;
        float bias;
        float weight;
        float[] desiredOutput = { 1, 1, 1, 1, 1, -1, -1, -1 };
        float[] receviedOutput = new float[8];
        float output;
        float[] error = new float[8];
        float sum_error = 0;
        float[] apple1 = { 0.21835F, 0.81884F, 1 };
        float[] apple2 = { 0.14115F, 0.83535F, 1 };
        float[] apple3 = { 0.37022F, 0.8111F, 1 };
        float[] apple4 = { 0.31565F, 0.83101F, 1 };
        float[] apple5 = { 0.36484F, 0.8518F, 1 };
        float[] apple6 = { 0.46111F, 0.82518F, 1 };
        float[] apple7 = { 0.55223F, 0.83449F, 1 };
        float[] apple8 = { 0.16975F, 0.84049F, 1 };
        float[] apple9 = { 0.49187F, 0.80889F, 1 };
        float[] pear1 = { 0.14913F, 0.77104F, -1 };
        float[] pear2 = { 0.18474F, 0.6279F, -1 };
        float[] pear3 = { 0.08838F, 0.62068F, -1 };
        float[] pear4 = { 0.098166F, 0.79092F, -1 };
        //--------------------------------------------------------------------------------------------------------------------------------------
        // giving random numbers to w0, w1, and bias only 1 time 

        float[] initializeWeight()
        {
            Random rnd0 = new Random();

            for (int i = 0; i < 2; i++)
            {
                float random0 = (float)rnd0.NextDouble();
                weights[i] = (float)rnd0.NextDouble();
                Console.WriteLine("weights[" + i + "] before training =" + weights[i]);
            }
            return weights;
        }

        float initializeBias()
        {
            Random bs = new Random();
            bias = (float)bs.NextDouble();
            return bias;
            Console.WriteLine("bias before training : " + bias);
        }

        //decision making and updating algorithms for single line percepteron
        //--------------------------------------------------------------------------------------------------------------------------------------
        int DECISION_MAKING_ALGORITHM(Double v)
        {

            if (v >= 0)
            {

                return 1;
            }
            else
            {
                return -1;
            }

        }

        float[] calcualteOutput(float[] weights, float bias)
        {
            //Apple1***********************************************************************
            Console.WriteLine("**********APPLE 1****************");
            v = (apple1[0] * weights[0] + apple1[1] * weights[1] + bias);

            Console.WriteLine("v for apple 1 = " + v);

            output = DECISION_MAKING_ALGORITHM(v);
            Console.WriteLine("y for apple 1 = " + output);
            receviedOutput[0] = output;

            //Apple2***************************************************************************
            Console.WriteLine("**********APPLE 2****************");

            v = (apple2[0] * weights[0] + apple2[1] * weights[1] + bias);

            Console.WriteLine("v for apple 2 = " + v);

            output = DECISION_MAKING_ALGORITHM(v);
            Console.WriteLine("y for apple 2 = " + output);
            receviedOutput[1] = output;

            //Apple 3*********************************************************************
            Console.WriteLine("**********APPLE 3****************");

            v = (apple3[0] * weights[0] + apple3[1] * weights[1] + bias);

            Console.WriteLine("v for apple 3 = " + v);

            output = DECISION_MAKING_ALGORITHM(v);
            Console.WriteLine("y for apple 3 = " + output);
            receviedOutput[2] = output;


            //Apple4***************************************************************************
            Console.WriteLine("**********APPLE 4****************");

            v = (apple4[0] * weights[0] + apple4[1] * weights[1] + bias);

            Console.WriteLine("v for apple 4 = " + v);

            output = DECISION_MAKING_ALGORITHM(v);
            Console.WriteLine("y for apple 4 = " + output);
            receviedOutput[3] = output;

            //Apple5***************************************************************************
            Console.WriteLine("**********APPLE 5****************");

            v = (apple5[0] * weights[0] + apple5[1] * weights[1] + bias);

            Console.WriteLine("v for apple 5 = " + v);

            output = DECISION_MAKING_ALGORITHM(v);
            Console.WriteLine("y for apple 5 = " + output);
            receviedOutput[4] = output;

            //Pear1**********************************************************************
            Console.WriteLine("***************PEAR1******************");
            v = (pear1[0] * weights[0] + pear1[1] * weights[1] + bias);

            Console.WriteLine("v for pear1 = " + v);

            output = DECISION_MAKING_ALGORITHM(v);
            Console.WriteLine("y for pear1 = " + output);
            receviedOutput[5] = output;

            //Pear2**********************************************************************
            Console.WriteLine("***************PEAR2******************");
            v = (pear2[0] * weights[0] + pear2[1] * weights[1] + bias);

            Console.WriteLine("v for pear2 = " + v);

            output = DECISION_MAKING_ALGORITHM(v);
            Console.WriteLine("y for pear2 = " + output);
            receviedOutput[6] = output;

            //Pear3**********************************************************************
            Console.WriteLine("***************PEAR3******************");
            v = (pear3[0] * weights[0] + pear3[1] * weights[1] + bias);

            Console.WriteLine("v for pear3 = " + v);

            output = DECISION_MAKING_ALGORITHM(v);
            Console.WriteLine("y for pear3 = " + output);
            receviedOutput[7] = output;

            //---------------------------------------------------------------------------------------------------------------------
            //Filling error matrix with errors (if any fruit has error, it will placed in appropriate place)

            error[0] = desiredOutput[0] - receviedOutput[0];
            error[1] = desiredOutput[1] - receviedOutput[1];
            error[2] = desiredOutput[2] - receviedOutput[2];
            error[3] = desiredOutput[3] - receviedOutput[3];
            error[4] = desiredOutput[4] - receviedOutput[4];
            error[5] = desiredOutput[5] - receviedOutput[5];
            error[6] = desiredOutput[6] - receviedOutput[6];
            error[7] = desiredOutput[7] - receviedOutput[7];



            //Sending received output and desired output array to screen(before training)

            foreach (double rcvdoutp in receviedOutput)
            {
                Console.Write(rcvdoutp + ",");
            }
            Console.WriteLine();

            foreach (double dsrdoutpt in desiredOutput)
            {
                Console.Write(dsrdoutpt + ",");
            }
            Console.WriteLine();
            //checking which fruit has error

            if (error[0] != 0)
            {
                float[] updateSet = new float[6];

                updateSet[0] = weights[0];
                updateSet[1] = apple1[0];
                updateSet[2] = weights[1];
                updateSet[3] = apple1[1];
                updateSet[4] = error[0];
                updateSet[5] = bias;


                return updateSet;
            }

            else if (error[1] != 0)
            {

                float[] updateSet = new float[6];

                updateSet[0] = weights[0];
                updateSet[1] = apple2[0];
                updateSet[2] = weights[1];
                updateSet[3] = apple2[1];
                updateSet[4] = error[1];
                updateSet[5] = bias;

                return updateSet;
            }

            else if (error[2] != 0)
            {

                float[] updateSet = new float[6];

                updateSet[0] = weights[0];
                updateSet[1] = apple3[0];
                updateSet[2] = weights[1];
                updateSet[3] = apple3[1];
                updateSet[4] = error[2];
                updateSet[5] = bias;


                return updateSet;
            }

            else if (error[3] != 0)
            {
                float[] updateSet = new float[6];

                updateSet[0] = weights[0];
                updateSet[1] = apple4[0];
                updateSet[2] = weights[1];
                updateSet[3] = apple4[1];
                updateSet[4] = error[3];
                updateSet[5] = bias;

                return updateSet;
            }

            else if (error[4] != 0)
            {

                float[] updateSet = new float[6];

                updateSet[0] = weights[0];
                updateSet[1] = apple5[0];
                updateSet[2] = weights[1];
                updateSet[3] = apple5[1];
                updateSet[4] = error[4];
                updateSet[5] = bias;


                return updateSet;
            }

            else if (error[5] != 0)
            {


                float[] updateSet = new float[6];

                updateSet[0] = weights[0];
                updateSet[1] = pear1[0];
                updateSet[2] = weights[1];
                updateSet[3] = pear1[1];
                updateSet[4] = error[5];
                updateSet[5] = bias;

                return updateSet;
            }

            else if (error[6] != 0)
            {
                float[] updateSet = new float[6];

                updateSet[0] = weights[0];
                updateSet[1] = pear2[0];
                updateSet[2] = weights[1];
                updateSet[3] = pear2[1];
                updateSet[4] = error[6];
                updateSet[5] = bias;

                return updateSet;
            }

            else if (error[7] != 0)
            {
                float[] updateSet = new float[6];

                updateSet[0] = weights[0];
                updateSet[1] = pear3[0];
                updateSet[2] = weights[1];
                updateSet[3] = pear3[1];
                updateSet[4] = error[7];
                updateSet[5] = bias;

                return updateSet;
            }

            else
            {
                float[] updateSet = new float[6];

                updateSet[0] = 0;
                return updateSet;
            }


        }


        //***************-- Update--**************************************************************************************

        float updateWeight(float weight, float error, float input, float learningrate)
        {
            weight += learningRate * error * input;

            return weight;
        }


        float updateBias(float bias, float error, float learningrate)
        {
            bias += error * learningRate;
            return bias;

        }

        static void Main(string[] args)
        {

            Program pg = new Program();

            //------------------------------------------------------------------------------------------------------------------          

            pg.weights = pg.initializeWeight();
            pg.bias = pg.initializeBias();
            float[] updateSet = pg.calcualteOutput(pg.weights, pg.bias);

            Console.WriteLine();
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("weights[" + i + "] = " + pg.weights[i]);
            }


            int k = 0;
            //***********************----training---**********************************************
            while (updateSet[0] != 0)
            {
                k++;
                pg.weights[0] = pg.updateWeight(updateSet[0], updateSet[4], updateSet[1], pg.learningRate);
                pg.weights[1] = pg.updateWeight(updateSet[2], updateSet[4], updateSet[3], pg.learningRate);
                pg.bias = pg.updateBias(updateSet[5], updateSet[4], pg.learningRate);
                updateSet = pg.calcualteOutput(pg.weights, pg.bias);
                Console.WriteLine("------------------------------------------------");
            }
            
            Console.WriteLine("program finded universal values at "+ k + "th try");
            Console.WriteLine("updated universal weight[0] = " + pg.weights[0]);
            Console.WriteLine("updated universal weight[1] = " + pg.weights[1]);
            Console.WriteLine("updated bias = " + pg.bias);

        }
    }
}

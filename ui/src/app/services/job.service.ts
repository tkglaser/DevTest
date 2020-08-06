import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { JobModel } from '../models/job.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class JobService {

  constructor(private httpClient: HttpClient) { }

  public GetJobs(): Observable<JobModel[]> {
    return this.httpClient.get<JobModel[]>(`${environment.apiEndpoint}/job`);
  }

  public GetJob(jobId: number): Observable<JobModel> {
    return this.httpClient.get<JobModel>(`${environment.apiEndpoint}/job/${jobId}`);
  }

  public CreateJob(job: JobModel): Promise<object> {
    return this.httpClient.post(`${environment.apiEndpoint}/job`, job).toPromise();
  }
}

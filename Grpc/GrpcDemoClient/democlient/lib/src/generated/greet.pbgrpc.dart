///
//  Generated code. Do not modify.
//  source: greet.proto
//
// @dart = 2.12
// ignore_for_file: annotate_overrides,camel_case_types,constant_identifier_names,directives_ordering,library_prefixes,non_constant_identifier_names,prefer_final_fields,return_of_invalid_type,unnecessary_const,unnecessary_import,unnecessary_this,unused_import,unused_shown_name

import 'dart:async' as $async;

import 'dart:core' as $core;

import 'package:grpc/service_api.dart' as $grpc;
import 'greet.pb.dart' as $0;
export 'greet.pb.dart';

class GreeterClient extends $grpc.Client {
  static final _$sayHello = $grpc.ClientMethod<$0.HelloRequest, $0.HelloReply>(
      '/greet.Greeter/SayHello',
      ($0.HelloRequest value) => value.writeToBuffer(),
      ($core.List<$core.int> value) => $0.HelloReply.fromBuffer(value));

  GreeterClient($grpc.ClientChannel channel,
      {$grpc.CallOptions? options,
      $core.Iterable<$grpc.ClientInterceptor>? interceptors})
      : super(channel, options: options, interceptors: interceptors);

  $grpc.ResponseFuture<$0.HelloReply> sayHello($0.HelloRequest request,
      {$grpc.CallOptions? options}) {
    return $createUnaryCall(_$sayHello, request, options: options);
  }
}

abstract class GreeterServiceBase extends $grpc.Service {
  $core.String get $name => 'greet.Greeter';

  GreeterServiceBase() {
    $addMethod($grpc.ServiceMethod<$0.HelloRequest, $0.HelloReply>(
        'SayHello',
        sayHello_Pre,
        false,
        false,
        ($core.List<$core.int> value) => $0.HelloRequest.fromBuffer(value),
        ($0.HelloReply value) => value.writeToBuffer()));
  }

  $async.Future<$0.HelloReply> sayHello_Pre(
      $grpc.ServiceCall call, $async.Future<$0.HelloRequest> request) async {
    return sayHello(call, await request);
  }

  $async.Future<$0.HelloReply> sayHello(
      $grpc.ServiceCall call, $0.HelloRequest request);
}

class InstrumentClient extends $grpc.Client {
  static final _$readStatus =
      $grpc.ClientMethod<$0.ReadStatusRequest, $0.ReadStatusResponse>(
          '/greet.Instrument/ReadStatus',
          ($0.ReadStatusRequest value) => value.writeToBuffer(),
          ($core.List<$core.int> value) =>
              $0.ReadStatusResponse.fromBuffer(value));

  InstrumentClient($grpc.ClientChannel channel,
      {$grpc.CallOptions? options,
      $core.Iterable<$grpc.ClientInterceptor>? interceptors})
      : super(channel, options: options, interceptors: interceptors);

  $grpc.ResponseFuture<$0.ReadStatusResponse> readStatus(
      $0.ReadStatusRequest request,
      {$grpc.CallOptions? options}) {
    return $createUnaryCall(_$readStatus, request, options: options);
  }
}

abstract class InstrumentServiceBase extends $grpc.Service {
  $core.String get $name => 'greet.Instrument';

  InstrumentServiceBase() {
    $addMethod($grpc.ServiceMethod<$0.ReadStatusRequest, $0.ReadStatusResponse>(
        'ReadStatus',
        readStatus_Pre,
        false,
        false,
        ($core.List<$core.int> value) => $0.ReadStatusRequest.fromBuffer(value),
        ($0.ReadStatusResponse value) => value.writeToBuffer()));
  }

  $async.Future<$0.ReadStatusResponse> readStatus_Pre($grpc.ServiceCall call,
      $async.Future<$0.ReadStatusRequest> request) async {
    return readStatus(call, await request);
  }

  $async.Future<$0.ReadStatusResponse> readStatus(
      $grpc.ServiceCall call, $0.ReadStatusRequest request);
}
